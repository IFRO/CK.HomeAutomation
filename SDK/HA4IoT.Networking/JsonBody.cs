﻿using System;
using System.Text;
using Windows.Data.Json;
using HA4IoT.Contracts.Networking;

namespace HA4IoT.Networking
{
    public class JsonBody : IHttpBody
    {
        public JsonBody(IJsonValue content)
        {
            if (content == null) throw new ArgumentNullException(nameof(content));
            
            Content = content;            
        }

        public IJsonValue Content { get; }

        public string MimeType { get; private set; } = MimeTypeProvider.Json;

        public byte[] ToByteArray()
        {
            return Encoding.UTF8.GetBytes(Content.Stringify());
        }

        public JsonBody WithMimeType(string mimeType)
        {
            if (mimeType == null) throw new ArgumentNullException(nameof(mimeType));

            MimeType = mimeType;
            return this;
        }
    }
}
