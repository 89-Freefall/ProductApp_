using System;

namespace ProductApp.Services
{
    public interface ITimeProvider
    {
        DateTime GetCurrentTime();
    }
}