
namespace BookMyDesk.SharedKernel.Specifications
{
    public class Pagination<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyCollection<T> Data { get; set; }
        public Pagination(int _pageIndex, int _pageSize, int _count, IReadOnlyCollection<T> _data)
        {
            PageIndex = _pageIndex;
            PageSize = _pageSize;
            Count = _count;
            Data = _data;
        }
    }
}
