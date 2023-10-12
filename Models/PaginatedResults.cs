namespace Models
{
    public class PaginatedResults<T>
    {
        public PaginatedResults()
        {
            Items = new List<T>();
        }
        
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public IList<T> Items { get; set; }
    }
}