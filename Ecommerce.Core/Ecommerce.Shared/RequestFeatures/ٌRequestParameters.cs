using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared;


public abstract class RequestParameters
{
    const int maxPageSize = 50;
    private int _pageSize = 10;

    [Range(1, int.MaxValue)]
    public int PageNumber { get; set; } = 1;
    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
    }
}