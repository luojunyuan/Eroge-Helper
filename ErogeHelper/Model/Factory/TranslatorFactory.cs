﻿using System;
using System.Collections.Generic;
using System.Linq;
using ErogeHelper.Common.Enum;
using ErogeHelper.Model.Factory.Interface;
using ErogeHelper.Model.Factory.Translator;
using ErogeHelper.Model.Repository;

namespace ErogeHelper.Model.Factory
{
    public class TranslatorFactory : ITranslatorFactory
    {
        public TranslatorFactory(EhConfigRepository ehConfigRepository)
        {
            AllInstance = new List<ITranslator>
            {
                new BaiduApiTranslator(ehConfigRepository),
                new YeekitTranslator(ehConfigRepository),
                new BaiduWebTranslator(ehConfigRepository),
                new CaiyunTranslator(ehConfigRepository),
                new CloudTranslator(ehConfigRepository),
                //new AlapiTranslator(ehConfigRepository),
                new YoudaoTranslator(ehConfigRepository),
                new NiuTransTranslator(ehConfigRepository),
                new GoogleCnTranslator(ehConfigRepository),
                new TencentMtTranslator(ehConfigRepository),
            };
        }

        public List<ITranslator> AllInstance { get; }

        public List<ITranslator> GetEnabledTranslators() => AllInstance.Where(translator => translator.IsEnable).ToList();

        // QUESTION: 类似这样的Exception没法catch？
        public ITranslator GetTranslator(TranslatorName name) =>
            AllInstance.SingleOrDefault(translator => translator.Name == name) ??
            throw new Exception($"No translator {name}");
    }
}