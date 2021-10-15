﻿using JsonDumper.Converters;
using NASB_Parser;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonDumper
{
    internal class Program
    {
        private static void Write(string dst, string fullPath)
        {
            var watch = new Stopwatch();
            watch.Start();
            BulkSerializer ser;
            using (var fsread = File.OpenRead(fullPath))
                ser = new BulkSerializer(fsread);
            watch.Stop();
            Console.WriteLine($"Parsing took: {watch.Elapsed}");
            watch.Reset();
            watch.Start();
            var data = new SerialMoveset(ser);
            watch.Stop();
            Console.WriteLine($"Creation of type structure took: {watch.Elapsed}");
            watch.Reset();
            JsonSerializerOptions options = new()
            {
                Converters = {
                    new JsonStringEnumConverter(),
                    new CheckThingConverter(),
                    new FloatSourceConverter(),
                    new JumpConverter(),
                    new ObjectSourceConverter(),
                    new StateActionConverter(),
                    new Vector3Converter()
                }
            };
            Console.WriteLine("Json dump...");
            var outpFile = Path.GetFileNameWithoutExtension(fullPath);
            outpFile = Path.Combine(dst, outpFile) + ".json";
            watch.Start();
            if (File.Exists(outpFile))
                File.Delete(outpFile);
            using var fs = File.OpenWrite(outpFile);
            using var writer = new Utf8JsonWriter(fs);
            JsonSerializer.Serialize(writer, data, options);
            watch.Stop();
            Console.WriteLine($"Creation of JSON took: {watch.Elapsed}");
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter path to exported TextAsset data...");
            var p = @"D:\NASB_Managed\Characters";
            while (!File.Exists(p) && !Directory.Exists(p))
            {
                Console.WriteLine("Enter a valid path!");
                p = Console.ReadLine();
            }
            var dst = "output";
            if (Directory.Exists(dst))
            {
                Directory.Delete(dst, true);
            }
            Directory.CreateDirectory(dst);
            if (Directory.Exists(p))
            {
                foreach (var path in Directory.EnumerateFiles(p))
                {
                    Write(dst, path);
                }
                Console.WriteLine("Success!");
            }
            else if (File.Exists(p))
            {
                Write(dst, p);
                Console.WriteLine("Success!");
            }
        }
    }
}