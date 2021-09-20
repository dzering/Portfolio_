using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    public abstract class GameHandler : MonoBehaviour, IGameHandler
    {
        IGameHandler nextHandler;
        public virtual void Handle()
        {
            if(nextHandler != null)
            {
                nextHandler.Handle();
            }

        }

        public IGameHandler SetNext(IGameHandler handler)
        {
            nextHandler = handler;
            return handler;
        }
    }
}