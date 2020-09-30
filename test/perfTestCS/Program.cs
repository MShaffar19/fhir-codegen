﻿// <copyright file="Program.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// </copyright>
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Encodings.Web;
using Fhir.R4.Serialization;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using Newtonsoft.Json;

namespace PerfTestCS
{
    /// <summary>A program.</summary>
    public static class Program
    {
        /// <summary>The R4 test files.</summary>
        private static Dictionary<string, int> _r4TestFilesAndLoops = new Dictionary<string, int>
        {
            { "hl7.fhir.r4.examples-4.0.1\\package\\Patient-example.json", 10000 },
            { "hl7.fhir.r4.examples-4.0.1\\package\\Observation-2minute-apgar-score.json", 10000 },
            { "hl7.fhir.r4.examples-4.0.1\\package\\Bundle-resources.json", 10 },
        };

        /// <summary>Main entry-point for this application.</summary>
        /// <param name="fhirSpecDirectory">The full path to the directory where FHIR specifications are
        ///  downloaded and cached.</param>
        /// <returns>Exit-code for the process - 0 for success, else an error code.</returns>
        public static int Main(
            string fhirSpecDirectory = "")
        {
            if (string.IsNullOrEmpty(fhirSpecDirectory))
            {
                string testDir = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\fhirVersions");

                if (Directory.Exists(testDir))
                {
                    fhirSpecDirectory = testDir;
                }
                else
                {
                    testDir = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\..\\fhirVersions");

                    if (!Directory.Exists(testDir))
                    {
                        System.Console.WriteLine("Could not find fhir spec directory!");
                        return -1;
                    }

                    fhirSpecDirectory = testDir;
                }
            }

            if (FullParseTest(fhirSpecDirectory) == 0)
            {
                return 0;
            }

            //if (SystemTest(fhirSpecDirectory) == 0)
            //{
            //    return 0;
            //}

            Console.WriteLine("Running tests, this may take a few minutes...");
            Console.WriteLine(string.Empty);

            List<TimingResult> results = new List<TimingResult>();

            foreach (KeyValuePair<string, int> kvp in _r4TestFilesAndLoops)
            {
                string path = Path.Combine(fhirSpecDirectory, kvp.Key);

                if (!File.Exists(path))
                {
                    Console.WriteLine($"Test file: {path} not found!");
                    Console.WriteLine($"Please ensure that FHIR R4 + Examples have already been downloaded in {fhirSpecDirectory}.");
                    return -1;
                }

                results.AddRange(RunTests(path, kvp.Value));
            }

            foreach (TimingResult result in results)
            {
                DisplayResult(result);
            }

            // success
            return 0;
        }

        /// <summary>Tests full parse.</summary>
        /// <param name="fhirSpecDirectory">The full path to the directory where FHIR specifications are
        ///  downloaded and cached.</param>
        /// <returns>An int.</returns>
        private static int FullParseTest(string fhirSpecDirectory)
        {
            List<string> r4Dirs = new List<string>()
            {
                "hl7.fhir.r4.core-4.0.1",
                "hl7.fhir.r4.examples-4.0.1",
                "hl7.fhir.r4.expansions-4.0.1",
            };

            Dictionary<string, Exception> exceptions = new Dictionary<string, Exception>();

            foreach (string subDir in r4Dirs)
            {
                string currentDir = Path.GetFullPath(Path.Combine(fhirSpecDirectory, subDir));

                string[] files = Directory.GetFiles(currentDir, $"*.json", SearchOption.AllDirectories);

                foreach (string filename in files)
                {
                    string shortName = Path.GetFileNameWithoutExtension(filename);

                    switch (shortName)
                    {
                        case ".index":
                        case "package":
                            continue;
                    }

                    Console.WriteLine(filename);

                    try
                    {
                        var typed = System.Text.Json.JsonSerializer.Deserialize<Fhir.R4.Models.Resource>(File.ReadAllText(filename));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("FAILED");
                        exceptions.Add(shortName, ex);
                        return -1;
                    }
                }
            }

            return 0;
        }

        /// <summary>Tests system.</summary>
        /// <param name="fhirSpecDirectory">The full path to the directory where FHIR specifications are
        ///  downloaded and cached.</param>
        /// <returns>An int.</returns>
        private static int SystemTest(string fhirSpecDirectory)
        {
            string path = Path.Combine(fhirSpecDirectory, "hl7.fhir.r4.examples-4.0.1\\package\\Patient-example.json");
            // string path = Path.Combine(fhirSpecDirectory, "hl7.fhir.r4.examples-4.0.1\\package\\Observation-2minute-apgar-score.json");

            string exportName = Path.Combine(fhirSpecDirectory, "hl7.fhir.r4.examples-4.0.1\\package\\patient-example-roundtrip.json");

            //var serializeOptions = new System.Text.Json.JsonSerializerOptions();
            // serializeOptions.Converters.Add(new Test.R4.ResourceConverter());

            //serializeOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            // string fragment = "{" +
            //     "\"use\": \"home\"," +
            //     "\"type\": \"both\"," +
            //     "\"text\": \"534 Erewhon St PeasantVille, Rainbow, Vic  3999\"," +
            //     "\"line\": [" +
            //     "\"534 Erewhon St\"" +
            //     "]," +
            //     "\"city\": \"PleasantVille\"," +
            //     "\"district\": \"Rainbow\"," +
            //     "\"state\": \"Vic\"," +
            //     "\"postalCode\": \"3999\"," +
            //     "\"period\": {" +
            //     "\"start\": \"1974-12-25\"" +
            //     "}" +
            //     "}";

            // var typedFrag = System.Text.Json.JsonSerializer.Deserialize<Fhir.R4.Models.Address>(fragment, serializeOptions);

            // var obj = System.Text.Json.JsonSerializer.Deserialize(File.ReadAllText(path), typeof(Fhir.R4.Models.Resource), serializeOptions);
            var typed = System.Text.Json.JsonSerializer.Deserialize<Fhir.R4.Models.Patient>(File.ReadAllText(path), FhirSerializerOptions.Pretty);

            // var obj = System.Text.Json.JsonSerializer.Deserialize(File.ReadAllText(path), typeof(Test.R4.Resource), serializeOptions);
            // var typed = System.Text.Json.JsonSerializer.Deserialize<Test.R4.Patient>(File.ReadAllText(path), serializeOptions);

            //string val = System.Text.Json.JsonSerializer.Serialize<Fhir.R4.Models.Patient>(typed, serializeOptions);
            string val = System.Text.Json.JsonSerializer.Serialize<Fhir.R4.Models.Patient>(typed, FhirSerializerOptions.Pretty);

            File.WriteAllText(exportName, val);

            //Newtonsoft.Json.JsonConverter converter = new fhirNewtonsoft.ResourceConverter();
            //
            //var originalObj = JsonConvert.DeserializeObject<fhirNewtonsoft.Resource>(File.ReadAllText(path), converter);
            //string originalText = JsonConvert.SerializeObject(originalObj);
            //
            //var roundtripObj = JsonConvert.DeserializeObject<fhirNewtonsoft.Resource>(File.ReadAllText(exportName), converter);
            //string roundtripText = JsonConvert.SerializeObject(roundtripObj);

            //if (originalText != roundtripText)
            //{
            //    Console.WriteLine("Failed roundtrip!");
            //}
            //else
            //{
            //    Console.WriteLine("Passed roundtrip!");
            //}

            return 0;
        }

        /// <summary>Displays a result described by result.</summary>
        /// <param name="result">The result.</param>
        private static void DisplayResult(TimingResult result)
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine($"Results of file: {result.Filename}, {result.FileSize} bytes");
            Console.WriteLine($"{result.LibraryName}:");
            Console.WriteLine($"       Setup: {result.SetupTime / 1000.0}s");
            Console.WriteLine($" First Parse: {result.FirstParseTime / 1000.0}s");
            Console.WriteLine($"Looped Parse: {result.LoopedParseTime / 1000.0}s (avg: {(result.LoopedParseTime / 1000.0) / result.LoopCount})");
        }

        /// <summary>Executes the tests.</summary>
        /// <param name="filename">Filename of the file.</param>
        /// <param name="loops">   The loops.</param>
        private static List<TimingResult> RunTests(string filename, int loops)
        {
            List<TimingResult> results = new List<TimingResult>();

            // load the file
            string contents = File.ReadAllText(filename);

            results.Add(TestNetApi(filename, contents, loops));
            results.Add(TestBasicNewtonSoft(filename, contents, loops));
            results.Add(TestCS2(filename, contents, loops));

            return results;
        }

        /// <summary>Tests create structure 2.</summary>
        /// <param name="filename">Filename of the file.</param>
        /// <param name="contents">The contents.</param>
        /// <param name="loops">   The loops.</param>
        /// <returns>A TimingResult.</returns>
        private static TimingResult TestCS2(string filename, string contents, int loops)
        {
            TimingResult timingResult = new TimingResult(filename, contents.Length, "CS2", loops);

            Console.WriteLine($"Parsing {timingResult.Filename} with {timingResult.LibraryName}...");

            Stopwatch timer = Stopwatch.StartNew();

            var serializeOptions = new System.Text.Json.JsonSerializerOptions();
            //serializeOptions.Converters.Add(new Test.R4.ResourceConverter());

            timingResult.SetupTime = timer.ElapsedMilliseconds;

            timer.Restart();

            var firstParsed = System.Text.Json.JsonSerializer.Deserialize(contents, typeof(Fhir.R4.Models.Resource), serializeOptions);
            timingResult.FirstParseTime = timer.ElapsedMilliseconds;

            if (firstParsed == null)
            {
                Console.WriteLine($"Parse failed!");
                timingResult.FailureCount++;
            }

            timingResult.ResourceType = firstParsed.GetType().Name;

            timer.Restart();
            for (int i = 0; i < loops; i++)
            {
                var typed = System.Text.Json.JsonSerializer.Deserialize(contents, typeof(Fhir.R4.Models.Resource), serializeOptions);
                if (typed == null)
                {
                    Console.WriteLine($"Parse failed!");
                    timingResult.FailureCount++;
                }
            }

            timingResult.LoopedParseTime = timer.ElapsedMilliseconds;

            return timingResult;
        }

        /// <summary>Tests basic newton soft.</summary>
        /// <param name="filename">Filename of the file.</param>
        /// <param name="contents">The contents.</param>
        /// <param name="loops">   The loops.</param>
        /// <returns>A TimingResult.</returns>
        private static TimingResult TestBasicNewtonSoft(string filename, string contents, int loops)
        {
            TimingResult timingResult = new TimingResult(filename, contents.Length, "CSharpBasic-Newtonsoft", loops);

            Console.WriteLine($"Parsing {timingResult.Filename} with {timingResult.LibraryName}...");

            Stopwatch timer = Stopwatch.StartNew();

            Newtonsoft.Json.JsonConverter converter = new fhirNewtonsoft.ResourceConverter();

            timingResult.SetupTime = timer.ElapsedMilliseconds;

            timer.Restart();

            var firstParsed = Newtonsoft.Json.JsonConvert.DeserializeObject<fhirNewtonsoft.Resource>(contents, converter);
            timingResult.FirstParseTime = timer.ElapsedMilliseconds;

            if (firstParsed == null)
            {
                Console.WriteLine($"Parse failed!");
                timingResult.FailureCount++;
            }

            timingResult.ResourceType = firstParsed.GetType().Name;

            timer.Restart();
            for (int i = 0; i < loops; i++)
            {
                var typed = Newtonsoft.Json.JsonConvert.DeserializeObject<fhirNewtonsoft.Resource>(contents, converter);
                if (typed == null)
                {
                    Console.WriteLine($"Parse failed!");
                    timingResult.FailureCount++;
                }
            }

            timingResult.LoopedParseTime = timer.ElapsedMilliseconds;

            return timingResult;
        }

        /// <summary>Tests net API.</summary>
        /// <param name="filename">Filename of the file.</param>
        /// <param name="contents">The contents.</param>
        /// <param name="loops">   The loops.</param>
        /// <returns>A TimingResult.</returns>
        private static TimingResult TestNetApi(string filename, string contents, int loops)
        {
            Version version = System.Reflection.Assembly.GetAssembly(typeof(FhirJsonParser)).GetName().Version;

            TimingResult timingResult = new TimingResult(filename, contents.Length, $"FHIR Net API, R4: {version}", loops);

            Console.WriteLine($"Parsing {timingResult.Filename} with {timingResult.LibraryName}...");

            Stopwatch timer = Stopwatch.StartNew();

            FhirJsonParser jsonParser = new FhirJsonParser(
                new ParserSettings
                {
                    AcceptUnknownMembers = true,
                    AllowUnrecognizedEnums = true,
                });

            timingResult.SetupTime = timer.ElapsedMilliseconds;

            timer.Restart();

            var firstParsed = jsonParser.Parse(contents);
            timingResult.FirstParseTime = timer.ElapsedMilliseconds;

            if (firstParsed == null)
            {
                Console.WriteLine($"Parse failed!");
                timingResult.FailureCount++;
            }

            timingResult.ResourceType = firstParsed.GetType().Name;

            timer.Restart();
            for (int i = 0; i < loops; i++)
            {
                var typed = jsonParser.Parse(contents);
                if (typed == null)
                {
                    Console.WriteLine($"Parse failed!");
                    timingResult.FailureCount++;
                }
            }

            timingResult.LoopedParseTime = timer.ElapsedMilliseconds;

            return timingResult;
        }
    }
}
