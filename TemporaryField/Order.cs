namespace TemporaryField
{
    public class OberEatOrder
    {
        private readonly int _riceCount;
        private readonly int _soupCount;
        private readonly int _vegetableCount;
        private int _riceTotalMoney;
        private int _soupTotalMoney;
        private int _vegetableTotalMoney;
        private int _tempTotalMoney;

        public OberEatOrder(int riceCount, int soupCount, int vegetableCount)
        {
            _riceCount = riceCount;
            _soupCount = soupCount;
            _vegetableCount = vegetableCount;
        }

        public int GetPrice()
        {
            CalculateEachTotal();
            CalculateTotal();
            CalculateTransportFee();
            return _tempTotalMoney;
        }

        private void CalculateEachTotal()
        {
            _riceTotalMoney = _riceCount * 10;
            _soupTotalMoney = _soupCount * 25;
            _vegetableTotalMoney = _vegetableCount * 30;
        }

        public string GetOrderInfo()
        {
            return $"rice: {_riceCount}, soup: {_soupCount}, vegetable: {_vegetableCount}.";
        }

        private void CalculateTransportFee()
        {
            _tempTotalMoney += ((_riceCount + _soupCount + _vegetableCount) * 10);
        }

        private void CalculateTotal()
        {
            _tempTotalMoney = _riceTotalMoney + _soupTotalMoney + _vegetableTotalMoney;
        }
    }
}