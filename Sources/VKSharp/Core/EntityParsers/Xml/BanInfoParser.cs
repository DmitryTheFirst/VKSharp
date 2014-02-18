﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using VKSharp.Core.Entities;
using VKSharp.Core.Interfaces;
using VKSharp.Data.Executors;

namespace VKSharp.Core.EntityParsers.Xml {
    public class BanInfoParser : IXmlVKEntityParser<BanInfo> {
        public IExecutor Executor { get; set; }


        public void FillFromXml(IEnumerable<XmlNode> nodes, BanInfo entity) {
            foreach ( var node in nodes )
                this.UpdateFromFragment( node, entity );
        }

        public BanInfo ParseFromXml(XmlNode node) {
            return this.ParseFromXmlFragments(node.ChildNodes.OfType<XmlNode>());
        }

        public BanInfo[] ParseAllFromXml(IEnumerable<XmlNode> nodes) {
            return nodes.Select(this.ParseFromXml).ToArray();
        }

        public BanInfo ParseFromXmlFragments(IEnumerable<XmlNode> nodes) {
            var entity = new BanInfo();
            this.FillFromXml(nodes, entity);
            return entity;
        }

        public void UpdateFromFragment(XmlNode node, BanInfo entity) {
            switch ( node.Name ) {
                case"admin_id":
                    entity.AdminID = uint.Parse(node.InnerText);
                    break;
                case "date":
                    entity.AddDate = uint.Parse( node.InnerText );
                    break;
                case "end_date":
                    entity.EndDate = uint.Parse( node.InnerText );
                    break;
                case "reason":
                    entity.Reason = node.InnerText;
                    break;
                case "comment":
                    entity.Comment = node.InnerText;
                    break;
            }
        }
    }
}
