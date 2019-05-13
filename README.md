[![Build Status](https://dev.azure.com/andreasmewald/ExtensionsDataflow/_apis/build/status/moerwald.TplDataflow.Extension?branchName=master)](https://dev.azure.com/andreasmewald/ExtensionsDataflow/_build/latest?definitionId=5?branchName=master) 
 [![](https://img.shields.io/azure-devops/coverage/andreasmewald/ExtensionsDataflow/5.svg)](https://dev.azure.com/andreasmewald/ExtensionsDataflow)
 [![](https://img.shields.io/azure-devops/tests/andreasmewald/ExtensionsDataflow/5.svg)](https://dev.azure.com/andreasmewald/ExtensionsDataflow)
 [![](https://img.shields.io/nuget/v/TplDataFlow.Extension.svg)](https://www.nuget.org/packages/TplDataFlow.Extension/)
 [![](https://img.shields.io/nuget/dt/TplDataFlow.Extension.svg)](https://www.nuget.org/packages/TplDataFlow.Extension/)
 [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=moerwald_TplDataflow.Extension&metric=alert_status)](https://sonarcloud.io/dashboard?id=moerwald_TplDataflow.Extension)
 [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=moerwald_TplDataflow.Extension&metric=code_smells)](https://sonarcloud.io/dashboard?id=moerwald_TplDataflow.Extension)
 [![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=moerwald_TplDataflow.Extension&metric=ncloc)](https://sonarcloud.io/dashboard?id=moerwald_TplDataflow.Extension)
 [![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=moerwald_TplDataflow.Extension&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=moerwald_TplDataflow.Extension)
 
 
 
 # TplDataflow.Extension

In TPL dataflow methods like LinkTo, Post, SendAsync, ReceiveAsync are extension methods (located in Dataflow.cs). Extension methods always give you a hard time when trying to mock them in unit tests. Therefore this extension offers two adapter interfaces (ISourceBlockWrapper and ITargetBlockWrapper) allowing you to mock the most common TPL dataflow methods.
