﻿using System.Collections.Generic;
using VKSharp.Data.Api;

namespace VKSharp.Data.Request {
    public class VKRequest<T> {
        public string MethodName { get; set; }
        public VKToken Token { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}