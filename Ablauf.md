# Vorbereitung

 - LinqPad leeren
 - Aufmachen
   - Docker
     - Container Löschen
   - LinqPad
   - VS Preview
   - Powershell
   - Open


# Vortag Ablauf 

 - Werkzeuge
   - Werde eine Reihe Werkzeuge vorstellen
     - Wo ist die Applikation langsam?
     - Warum?
   - Nicht im Detail - keiner wird Profi
   - Ziel: „Da gibt es doch das eine Tool, das könnte mir hier helfen“
   - Achtung: Ich hüpfe zwischen den Tools

- Vorstellung
  - Interesse: technische Details 
    - Threads, Tasks, RX, EF, Garbage Collection, ...
    - APIs, Datenbanken, Services
 
 - Erstes Tool: `Benchmark.Net`
   - Das Tool für .Net Microbenchmarks
     - Isolierte Untersuchung von einzelnen Methoden oder Algorithmen
   - Einfaches Benchmark erstellen
     - Endian Shift
   - laufen lassen
     - Was macht BenchmarkDotNet?
       - Baut App in jeweiligem Target Framework
       - Stellt Windows auf High-Performance
       - Warmup
       - Misst Overhead
       - Führt Benchmark durch
       - Analysiert Outlier
       - Erstellt Reports
   
   - LinqPad Beispiel
     - LinqPad und Dump()   
     - String.Equals vs HashSet
     - Unterschied .Net 6 vs .Net 8
     - Equals vergleicht länge

 - --> Was sind gute Benchmarks 
   - Wichtig
     - Szenario
     - Umgebung

 - --> Wenn das so ein Aufwand ist, soll man überhaupt optimieren?
   - > "root of all evil"
   - Was heißt das für uns?
   - Sollen wir möglichst schlechten Code schreiben?
     > In DonaldKnuth's paper "StructuredProgrammingWithGoToStatements", he wrote: "Programmers waste enormous amounts of time thinking about, or worrying about, the speed of noncritical parts of their programs, and these attempts at efficiency actually have a strong negative impact when debugging and maintenance are considered. We should forget about small efficiencies, say about 97% of the time: premature optimization is the root of all evil. Yet we should not pass up our opportunities in that critical 3%."
   - > "We value maintainable code over premature optimization."

 - `dotnet counters`
   - Server Starten
   - Counter anschauen
   - CLI Tool zeigen
     - Download zeigen
   - auch möglich in Docker oder auf Prod Server. Braucht nur .Net Runtime.
   - Folien: 
     - Cool mit Grafana / Application Insights
     - Cool mit .Net Aspire

 - VS Performance Profiler
   - Beispiel mit Async, Counters und FileAccess
 
 - 

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


# Todo

 - GitHub-Seite fertig machen


