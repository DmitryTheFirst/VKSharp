﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKSharp.Core.Entities;
using VKSharp.Core.Enums;
using VKSharp.Data.Parameters;
using VKSharp.Data.Request;
using VKSharp.Helpers;

namespace VKSharp {
    public partial class VKApi {
        public async Task<User[]> FriendsGetAsync(
           uint userID,
           UserSortOrder order = UserSortOrder.ByID,
           uint? listID = null,
           uint offset = 0,
           ushort count = 100,
           UserFields fields = UserFields.First_Name | UserFields.Last_Name,
           NameCase nameCase = NameCase.Nom ) {
            var req = new VKRequest<User> {
                MethodName = "friends.get",
                Parameters = new Dictionary<string, string> {
                    { "fields", String.Join(",",MiscTools.GetUserFields(fields)) },
                    { "list_id", MiscTools.NullableString(listID) },
                    { "order", order==UserSortOrder.ByID?"":order.ToNCLString() },
                    { "user_id", userID.ToNCString() },
                    { "offset", offset.ToNCString() },
                    { "count", count.ToNCString() },
                    { "name_case", nameCase.ToNCLString() }
                },
                Token = this.IsLogged ? this.CurrenToken : null
            };
            return ( await this._executor.ExecAsync( req ) ).Data;
        }

        public async Task<User[]> FriendsGetByPhonesAsync(
           IEnumerable<ulong> phones,
           UserFields fields = UserFields.First_Name | UserFields.Last_Name ) {
            var req = new VKRequest<User> {
                MethodName = "friends.get",
                Parameters = new Dictionary<string, string> {
                    { "fields", String.Join(",",MiscTools.GetUserFields(fields)) },
                    { "phones", String.Join( ",", phones.Select(a=>"+"+a) ) }
                }
            };
            if ( !this.IsLogged )
                throw new InvalidOperationException( "This method requires auth!" );
            req.Token = this.CurrenToken;
            return ( await this._executor.ExecAsync( req ) ).Data;
        }

        public async Task<User[]> FriendsGetSuggestionsAsync(
            FriendSuggestionFilters filters = FriendSuggestionFilters.Everything,
            uint offset = 0,
            ushort count = 100,
            UserFields fields = UserFields.First_Name | UserFields.Last_Name,
            NameCase nameCase = NameCase.Nom ) {
            var req = new VKRequest<User> {
                MethodName = "friends.get",
                Parameters = new Dictionary<string, string> {
                    { "fields", String.Join(",",MiscTools.GetUserFields(fields)) },
                    { "filters", String.Join(",",MiscTools.GetFilterFields(filters)) },
                    { "offset", offset.ToNCString() },
                    { "count", count.ToNCString() },
                    { "name_case", nameCase.ToNCLString() }
                }
            };
            if ( !this.IsLogged )
                throw new InvalidOperationException( "This method requires auth!" );
            req.Token = this.CurrenToken;
            return ( await this._executor.ExecAsync( req ) ).Data;
        }
    }
}