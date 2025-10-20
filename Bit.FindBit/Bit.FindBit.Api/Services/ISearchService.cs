using Bit.FindBit.Core.Entities;
using Bit.FindBit.Dtos;

namespace Bit.FindBit.Services;

public interface ISearchService
{
    public GeneralResponse GetAll(QueryObject queryObj);
}