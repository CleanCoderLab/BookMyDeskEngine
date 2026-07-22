
using BookMyDesk.BuildingBlocks.MultiTenancy.Abstractions;

namespace BookMyDesk.BuildingBlocks.MultiTenancy.Context
{
    /// <summary>
    /// Stores the tenant context for the current logical execution flow.
    /// </summary>
    public sealed class TenantContextAccessor : ITenantContextAccessor
    {
        private static readonly AsyncLocal<TenantContextHolder?> _current = new();

        /// <inheritdoc />
        public TenantContext TenantContext =>
            _current.Value?.Context
            ?? throw new InvalidOperationException(
                "No tenant context has been established for this execution flow.");

        /// <inheritdoc />
        public void SetContext(TenantContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            var holder = _current.Value;

            if (holder is not null)
            {
                holder.Context = null;
            }

            _current.Value = new TenantContextHolder
            {
                Context = context
            };
        }

        /// <inheritdoc />
        public void Clear()
        {
            var holder = _current.Value;

            if (holder is not null)
            {
                holder.Context = null;
            }

            _current.Value = null;
        }

        /// <summary>
        /// Wrapper used by AsyncLocal to isolate execution contexts.
        /// </summary>
        private sealed class TenantContextHolder
        {
            public TenantContext? Context;
        }
    }

    //public sealed class TenantContextAccessor : ITenantContextAccessor
    //{
    //    private static readonly AsyncLocal<TenantContextHolder?> _current = new();

    //    public TenantContext TenantContext
    //    {
    //        get => _current.Value?.Context ?? throw new InvalidOperationException(
    //            "No tenant context has been established for this execution flow. " +
    //            "Ensure TenantResolutionMiddleware runs before this is accessed.");
    //        set
    //        {
    //            var holder = _current.Value;
    //            if (holder is not null)
    //                holder.Context = null;          // detach old holder from any lingering refs

    //            if (value is not null)
    //                _current.Value = new TenantContextHolder { Context = value };
    //        }
    //    }

    //    private sealed class TenantContextHolder
    //    {
    //        public TenantContext? Context;
    //    }
    //}

}