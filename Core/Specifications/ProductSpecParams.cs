namespace Core.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSix = 50;
        
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 2;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value>MaxPageSix) ? MaxPageSix : value;
            }
        }

        public int? BrandId { get; set; }

        public int? TypeId { get; set; }

        public string  Sort { get; set; }

        private string _search;
        public string Search
        {
            get
            {
                return _search;
            }
            set 
            {
                _search = value.ToLower();
            }
        }
    }
}