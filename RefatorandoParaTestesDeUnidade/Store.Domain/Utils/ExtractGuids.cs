using System;
using System.Collections.Generic;
using Store.Domain.Commands;

namespace Store.Domain.Utils
{
    public static class ExtractGuids
    {
        public static IEnumerable<Guid> Extract(IList<CreateOrderItemCommand> command)
        {
            var guids = new List<Guid>();
            foreach (var item in command)
                guids.Add(item.Product);

            return guids;
        }
    }
}