﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Infrastructures
{
    public static class SessionExtensions //???
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            var serializedDate = JsonConvert.SerializeObject(value);
            session.SetString(key, serializedDate);
        }
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null
            ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}
