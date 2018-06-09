﻿/*
 License: https://github.com/chengderen/Smartflow/blob/master/LICENSE 
 Home page: https://github.com/chengderen/Smartflow
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Dapper;
using Smartflow.Enums;

namespace Smartflow.Elements
{
    [XmlInclude(typeof(Node))]
    public class Transition : Element, IRelationShip
    {
        public string RNID
        {
            get;
            set;
        }

        public long SOURCE
        {
            get;
            set;
        }

        [XmlAttribute("to")]
        public long DESTINATION
        {
            get;
            set;
        }

        [XmlAttribute("expression")]
        public string EXPRESSION
        {
            get;
            set;
        }

        internal override void Persistent()
        {
            string sql = "INSERT INTO T_TRANSITION(NID,RNID,APPELLATION,DESTINATION,SOURCE,INSTANCEID,EXPRESSION) VALUES(@NID,@RNID,@APPELLATION,@DESTINATION,@SOURCE,@INSTANCEID,@EXPRESSION)";
            Connection.Execute(sql, new
            {
                NID = Guid.NewGuid().ToString(),
                RNID = RNID,
                APPELLATION = APPELLATION,
                DESTINATION = DESTINATION,
                SOURCE = SOURCE,
                INSTANCEID = INSTANCEID,
                EXPRESSION = EXPRESSION
            });
        }
    }
}
