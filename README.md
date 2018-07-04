﻿# TplDataflow.Extension

In TPL dataflow methods like LinkTo, Post, SendAsync, ReceiveAsync are extension methods (located in Dataflow.cs). Extension methods always give you a hard time when trying to mock them in unit tests. Therefore this extension offers two adapter interfaces (ISourceBlockWrapper and ITargetBlockWrapper) allowing you to mock the most common TPL dataflow methods.
