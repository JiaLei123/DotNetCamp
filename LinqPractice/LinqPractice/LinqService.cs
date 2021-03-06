﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    public class LinqService
    {
        private LinqService(){}

        private static LinqService instance = new LinqService();

        public static LinqService getInstance()
        {
            return instance;
        }

        public LinqBase CreateLinq(string name)
        {
            string cmd = name.ToLower().Trim();
            LinqBase result;

            switch (cmd)
            {
                case Constants.orderby:
                    result = new OrderBy();
                    break;
                case Constants.where:
                    result = new WhereOperation();
                    break;
                case Constants.select:
                    result = new SelectOperation();
                    break;
                case Constants.groupby:
                    result = new GroupByOperation();
                    break;
                case Constants.covert:
                    result = new CaseOperation();
                    break;
                case Constants.collection:
                    result = new CollectionOperation();
                    break;
                case Constants.join:
                    result = new JoinOperation();
                    break;
                default:
                    throw new Exception();
            }
            return result;
        }

        public List<LinqBase> CreateLinqFactory(string name)
        {
            string cmd = name.ToLower().Trim();
            IFactory result;
            switch (cmd)
            {
                case Constants.Simple:
                    result = new SimpleQuery();
                    break;
                case Constants.Adv:
                    result = new AdvanceQuery();
                    break;
                default:
                    throw new Exception();
            }
            return result.Create();
        }
    }
}
