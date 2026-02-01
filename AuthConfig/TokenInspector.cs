//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Text.Json;

//namespace MultiAuth03.Auth
//{
//    public static class TokenInspector
//    {
     
//            public static bool IsExpired(string storagePath)
//            {
//                var json = File.ReadAllText(storagePath);
//                var doc = JsonDocument.Parse(json);

//                var token = doc.RootElement
//                    .GetProperty("origins")[0]
//                    .GetProperty("localStorage")
//                    .EnumerateArray()
//                    .First(x => x.GetProperty("name").GetString()
//                        .Contains("token"))
//                    .GetProperty("value")
//                    .GetString();

//                var jwtPayload = token.Split('.')[1];
//                var payloadJson = Encoding.UTF8.GetString(
//                    Convert.FromBase64String(Pad(jwtPayload)));

//                var payload = JsonDocument.Parse(payloadJson);
//                var exp = payload.RootElement.GetProperty("exp").GetInt64();

//                return DateTimeOffset.UtcNow.ToUnixTimeSeconds() > exp;
//            }

//            private static string Pad(string input)
//            {
//                return input.PadRight(input.Length +
//                    (4 - input.Length % 4) % 4, '=');
//            }
//        }

//    }
