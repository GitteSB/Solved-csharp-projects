﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WebShopV10
{
    public class OrderV3
    {
        private const double StateTaxHighLimitAmount = 40.0;
        private const double StateTaxHighPercentage = 10.00;
        private const double StateTaxLowPercentage = 8.00;
        private const double ShippingHighCost = 9.00;
        private const double ShippingLowCost = 5.00;
        private const int ShippingHighCostLimitItems = 3;
        private const double EUTaxPercentage = 2.00;
        private const double EUTaxMinimumAmount = 1.00;

        private List<double> _itemPriceList;

        public OrderV3(List<double> itemPriceList)
        {
            _itemPriceList = itemPriceList;
        }

        public double TotalOrderPrice
        {
            get
            {
                ForEachItem(AddStateTaxToItem);
                ForEachItem(AddShippingCostToItem);
                ForEachItem(AddEUTaxToItem);

                return _itemPriceList.Sum();
            }
        }

        public void ForEachItem(Action<int> action)
        {
            for (int index = 0; index < _itemPriceList.Count; index++)
            {
                action(index);
            }
        }

        private void AddAmount(int index, double amount)
        {
            _itemPriceList[index] = _itemPriceList[index] + amount;
        }

        private void AddEUTaxToItem(int index)
        {
            AddAmount(index, _itemPriceList[index] * (EUTaxPercentage / 100) > EUTaxMinimumAmount
                           ? _itemPriceList[index] * (EUTaxPercentage / 100)
                           : EUTaxMinimumAmount);
        }

        private void AddStateTaxToItem(int index)
        {
            AddAmount(index, _itemPriceList[index] < StateTaxHighLimitAmount
                           ? _itemPriceList[index] * StateTaxHighPercentage / 100
                           : _itemPriceList[index] * StateTaxLowPercentage / 100);
        }

        private void AddShippingCostToItem(int index)
        {
            AddAmount(index, index < ShippingHighCostLimitItems
                           ? ShippingHighCost
                           : ShippingLowCost);
        }
    }
}
