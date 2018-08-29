echo off

REM --------------------------------------------------------------------------------------------------------------------
REM -- Subsdrive will set a drive letter to the referenced assemblies so that everything can be found and referenced  --
REM -- from the same directory for all developers. A developer can map it's own location to the correct location      --
REM --------------------------------------------------------------------------------------------------------------------

subst /D R:
subst R: "%CD%"