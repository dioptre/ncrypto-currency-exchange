﻿using Lostics.NCryptoExchange.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lostics.NCryptoExchange.CoinEx
{
    public class CoinExMarket : Market
    {
        public CoinExMarket(CoinExMarketId id, string label, MarketStatistics statistics)
            : base(id, id.BaseCurrencyCode, id.QuoteCurrencyCode,
                label, statistics)
        {
        }

        public static CoinExMarket Parse(JObject marketJson)
        {
            CoinExMarketId marketId = new CoinExMarketId(marketJson.Value<int>("id"), marketJson.Value<string>("url_slug"));

            MarketStatistics marketStats = new MarketStatistics()
            {
                HighTrade = marketJson.Value<long>("rate_max") * CoinExExchange.PRICE_UNIT,
                LastTrade = marketJson.Value<long>("last_price") * CoinExExchange.PRICE_UNIT,
                LowTrade = marketJson.Value<long>("rate_min") * CoinExExchange.PRICE_UNIT,
                Volume24HBase = marketJson.Value<decimal>("market_volume")
            };

            return new CoinExMarket(marketId, marketId.UrlSlug, marketStats)
            {
                BaseId = marketJson.Value<int>("market_id"),
                QuoteId = marketJson.Value<int>("currency_id"),
                BuyFee = marketJson.Value<decimal>("buy_fee"),
                SellFee = marketJson.Value<decimal>("sell_fee"),
                UpdatedAt = marketJson.Value<DateTime>("updated_at")
            };
        }

        public int BaseId { get; set; }
        public int QuoteId { get; set; }
        public decimal BuyFee { get; set; }
        public decimal SellFee { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
