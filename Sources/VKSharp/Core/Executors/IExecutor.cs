﻿using System.IO;
using System.Threading.Tasks;
using VKSharp.Data.Request;

namespace VKSharp.Data.Executors {
    public interface IExecutor {
        Task<VKResponse<T>> ExecAsync<T>( VKRequest<T> request );
        Task<string> ExecRawAsync<T>( VKRequest<T> request );
        VKResponse<T> Parse<T>( string input );
        Task<Stream> ExecRawStreamAsync<T>( VKRequest<T> request );
        VKResponse<T> ParseStream<T>( Stream input );
    }
}