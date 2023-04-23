﻿using HotChocolate.Data.Filters;

namespace Bikes.API;

public class UnsignedIntOperationFilterInputType
: ComparableOperationFilterInputType<UnsignedIntType>
{
    protected override void Configure(IFilterInputTypeDescriptor descriptor)
    {
        descriptor.Name("UnsignedIntOperationFilterInputType");
        base.Configure(descriptor);
    }
}
