# Vortag Ablauf 

 - Einleitung
   - Vorstellung
   - Große Anzahl an Tools
 
 - Erstes Tool: `Benchmark.Net`
   - Projekt anlegen
   - Einfaches Benchmark erstellen
     - Endian Shift
   - laufen lassen
   - LinqPad Beispiel
     - String.Equals vs HashSet
     - Unterschied .Net 6 vs .Net 8

 - --> Was sind gute Benchmarks
   - Wichtig
     - Szenario
     - Umgebung
 - Wann soll man überhaupt optimieren?
   - > "root of all evil"
     > In DonaldKnuth's paper "StructuredProgrammingWithGoToStatements", he wrote: "Programmers waste enormous amounts of time thinking about, or worrying about, the speed of noncritical parts of their programs, and these attempts at efficiency actually have a strong negative impact when debugging and maintenance are considered. We should forget about small efficiencies, say about 97% of the time: premature optimization is the root of all evil. Yet we should not pass up our opportunities in that critical 3%."
   - > "We value maintainable code over premature optimization."

 - `dotnet counters`
   - auch möglich in Docker

 - `dotnet dump`
 
 - `dotTrace`
   - sync over async Problem 

 - `ProcMon`
   - Dateizugriffe

 - Weitere Tools (Links)
   - Logging
   - APM Tools
     - OpenTelemetry
     - Prometheus
     - Application Insights
   - Jetbrains tool suite
     - dotTrace
     - dotMemory
   - PerfView: Matrix
   - SysInternals
     - ProcMon
   - [siege](https://www.joedog.org/siege-home/)
   - [clumsy](https://github.com/jagt/clumsy)
     
 - Nette Links (?)
   - David Fowler [ASP.NET Core Diagnostic Scenarios](https://github.com/davidfowl/AspNetCoreDiagnosticScenarios)
   - Stephen Toub [Performance improvements in .Net 8](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-8/)





