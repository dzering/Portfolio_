using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    public interface IGameHandler
    {
        void Handle();
        IGameHandler SetNext(IGameHandler nextHandler);
    }
}