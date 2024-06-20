/*
 * SonarScanner for .NET
 * Copyright (C) 2016-2024 SonarSource SA
 * mailto:info AT sonarsource DOT com
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */
package com.sonar.it.scanner.msbuild.sonarqube;

import com.sonar.it.scanner.msbuild.utils.ScannerClassifier;
import com.sonar.it.scanner.msbuild.utils.TestUtils;
import com.sonar.orchestrator.Orchestrator;
import com.sonar.orchestrator.build.BuildResult;
import com.sonar.orchestrator.container.Edition;
import com.sonar.orchestrator.junit5.OrchestratorExtension;
import com.sonar.orchestrator.locator.FileLocation;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import org.apache.commons.io.FileUtils;
import org.junit.jupiter.api.extension.AfterAllCallback;
import org.junit.jupiter.api.extension.BeforeAllCallback;
import org.junit.jupiter.api.extension.ExtensionContext;
import org.junit.jupiter.api.io.TempDir;

import static org.junit.jupiter.api.Assertions.assertTrue;

public class Tests implements BeforeAllCallback, AfterAllCallback {

  public static final Orchestrator ORCHESTRATOR = OrchestratorExtension.builderEnv()
    .useDefaultAdminCredentialsForBuilds(true)
    .setSonarVersion(TestUtils.replaceLtsVersion(System.getProperty("sonar.runtimeVersion", "DEV")))
    .setEdition(Edition.DEVELOPER)
    .addPlugin(TestUtils.getMavenLocation("com.sonarsource.cpp", "sonar-cfamily-plugin", System.getProperty("sonar.cfamilyplugin.version", "LATEST_RELEASE")))
    .addPlugin(FileLocation.of(TestUtils.getCustomRoslynPlugin().toFile()))
    .addPlugin(TestUtils.getMavenLocation("org.sonarsource.dotnet", "sonar-csharp-plugin", System.getProperty("sonar.csharpplugin.version", "DEV")))
    .addPlugin(TestUtils.getMavenLocation("org.sonarsource.dotnet", "sonar-vbnet-plugin", System.getProperty("sonar.vbnetplugin.version", "DEV")))
    // The following plugin versions are hardcoded because `DEV` is not compatible with SQ < 8.9, to be fixed with this issue: https://github.com/SonarSource/sonar-scanner-msbuild/issues/1486
    .addPlugin(TestUtils.getMavenLocation("org.sonarsource.javascript", "sonar-javascript-plugin", System.getProperty("sonar.javascriptplugin.version", "7.4.4.15624")))
    .addPlugin(TestUtils.getMavenLocation("com.sonarsource.plsql", "sonar-plsql-plugin", System.getProperty("sonar.plsqlplugin.version", "3.6.1.3873")))
    .activateLicense()
    .build();

  private static volatile int usageCount;

  @Override
  public void beforeAll(ExtensionContext extensionContext) throws IOException {
    synchronized (Tests.class) {
      usageCount += 1;
      if (usageCount == 1) {
        ORCHESTRATOR.start();
        // To avoid a race condition in scanner file cache mechanism we analyze single project before any test to populate the cache
        analyzeEmptyProject(ScannerClassifier.NET_FRAMEWORK);
        analyzeEmptyProject(ScannerClassifier.NET);
      }
    }
  }

  @Override
  public void afterAll(ExtensionContext extensionContext) throws Exception {
    synchronized (Tests.class) {
      usageCount -= 1;
      if (usageCount == 0) {
        ORCHESTRATOR.stop();
      }
    }
  }

  @TempDir
  public Path basePath;

  private void analyzeEmptyProject(ScannerClassifier classifier) throws IOException {
    String localProjectKey = "my.project" + ".999";
    ORCHESTRATOR.getServer().restoreProfile(FileLocation.of("projects/ProjectUnderTest/TestQualityProfile.xml"));
    ORCHESTRATOR.getServer().provisionProject(localProjectKey, "sample");
    ORCHESTRATOR.getServer().associateProjectToQualityProfile(localProjectKey, "cs", "ProfileForTest");

    String token = TestUtils.getNewToken(ORCHESTRATOR);

    System.out.println("Qukoffl: " + basePath);
    Path projectDir = TestUtils.projectDir(basePath, "Empty");
    ORCHESTRATOR.executeBuild(TestUtils.newScanner(ORCHESTRATOR, projectDir, classifier, token)
      .addArgument("begin")
      .setProjectKey(localProjectKey)
      .setProjectName("sample")
      .setProperty("sonar.projectBaseDir", Paths.get(projectDir.toAbsolutePath().toString(), "Empty").toString())
      .setProjectVersion("1.0"));

    TestUtils.runMSBuild(ORCHESTRATOR, projectDir, "/t:Rebuild");

    BuildResult result = TestUtils.executeEndStepAndDumpResults(ORCHESTRATOR, projectDir, localProjectKey, token);
    assertTrue(result.isSuccess());
  }
}
