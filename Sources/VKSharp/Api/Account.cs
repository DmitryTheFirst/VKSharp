﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKSharp.Core.Entities;
using VKSharp.Data.Request;
using VKSharp.Helpers;
using VKSharp.Helpers.PrimitiveEntities;

namespace VKSharp {
    public partial class VKApi {
        public async Task<User[]> AccountGetBannedAsync(
            uint offset = 0,
            ushort count = 20 ) {
            var req = new VKRequest<User> {
                MethodName = "account.getBanned",
                Parameters = new Dictionary<string, string> {
                    { "offset", offset.ToNCString() },
                    { "count", count.ToNCString() }
                }
            };
            if ( !this.IsLogged )
                throw new InvalidOperationException( "This method requires auth!" );
            req.Token = this.CurrenToken;
            return ( await this._executor.ExecAsync( req ) ).Data;
        }
        public async Task<StructEntity<bool>> AccountSetOfflineAsync() {
            var req = new VKRequest<StructEntity<bool>> {
                MethodName = "account.setOffline",
                Parameters = new Dictionary<string, string>()
            };
            if (!this.IsLogged)
                throw new InvalidOperationException("This method requires auth!");
            req.Token = this.CurrenToken;
            return (await this._executor.ExecAsync(req)).Data.FirstOrDefault();
        }
        public async Task<StructEntity<bool>> AccountSetOnlineAsync(bool voip) {
            var req = new VKRequest<StructEntity<bool>> {
                MethodName = "account.setOnline",
                Parameters = new Dictionary<string, string> {
                    { "voip", (voip?1:0).ToNCString() }
                }
            };
            if (!this.IsLogged)
                throw new InvalidOperationException("This method requires auth!");
            req.Token = this.CurrenToken;
            return (await this._executor.ExecAsync(req)).Data.FirstOrDefault();
        }
        public async Task<StructEntity<bool>> AccountUnregisterDeviceAsync(string token) {
            var req = new VKRequest<StructEntity<bool>> {
                MethodName = "account.unregisterDevice",
                Parameters = new Dictionary<string, string> {
                    { "token", token }
                }
            };
            if (!this.IsLogged)
                throw new InvalidOperationException("This method requires auth!");
            req.Token = this.CurrenToken;
            return (await this._executor.ExecAsync(req)).Data.FirstOrDefault();
        }
        public async Task<StructEntity<bool>> AccountBanUserDeviceAsync(uint userId) {
            var req = new VKRequest<StructEntity<bool>> {
                MethodName = "account.banUser",
                Parameters = new Dictionary<string, string> {
                    { "user_id", userId.ToNCString() }
                }
            };
            if (!this.IsLogged)
                throw new InvalidOperationException("This method requires auth!");
            req.Token = this.CurrenToken;
            return (await this._executor.ExecAsync(req)).Data.FirstOrDefault();
        }
        public async Task<StructEntity<bool>> AccountUnbanUserDeviceAsync(uint userId) {
            var req = new VKRequest<StructEntity<bool>> {
                MethodName = "account.unbanUser",
                Parameters = new Dictionary<string, string> {
                    { "user_id", userId.ToNCString() }
                }
            };
            if (!this.IsLogged)
                throw new InvalidOperationException("This method requires auth!");
            req.Token = this.CurrenToken;
            return (await this._executor.ExecAsync(req)).Data.FirstOrDefault();
        }
        public async Task<StructEntity<bool>> AccountSetInfoAsync(uint? intro) {
            var req = new VKRequest<StructEntity<bool>> {
                MethodName = "account.setInfo",
                Parameters = new Dictionary<string, string> {
                    { "intro", MiscTools.NullableString( intro ) }
                }
            };
            if (!this.IsLogged)
                throw new InvalidOperationException("This method requires auth!");
            req.Token = this.CurrenToken;
            return (await this._executor.ExecAsync(req)).Data.FirstOrDefault();
        }

    }
}
