﻿/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using QuantConnect.ToolBox.KrakenDownloader;

namespace QuantConnect.Brokerage.ToolBox
{
    static class Program
    {
        static void Main(string[] args)
        {
            var downloader = new KrakenDataDownloader();

            var bars = downloader.Get(Symbol.Create("BTCUSD", SecurityType.Crypto, Market.Kraken), Resolution.Minute, DateTime.UtcNow - TimeSpan.FromHours(1), DateTime.UtcNow);

            int counter = 0;
            foreach (var bar in bars)
            {
                counter++;
                Console.WriteLine($"Returned bar #{counter} : {bar}");
            }
            
            Console.WriteLine($"Returned bars - {counter} (Should be 60)");
        }
    }
}