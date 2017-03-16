using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public interface IWhen<T>
    {
        IThen<T> When(params bool[] args);
    }

    public interface IThen<T>
    {
        IWhenElse<T> Then(Action action);
    }

    public interface IElse<T>
    {
        IWhen<T> Else(Action action);
    }

    public interface IWhenElse<T> : IWhen<T>, IElse<T>
    {
        
    }

    public interface IThenElse<T> : IThen<T>, IElse<T>
    {
        
    }

    public class Evaluate<T> : IThenElse<T>, IWhenElse<T>
    {
        private List<T> Evaluations { get; set; }

        private bool _result;

        public Evaluate(params T[] evaluations)
        {
            Evaluations = evaluations.ToList();
        }
        
        public IThen<T> When(params bool[] args)
        {
            _result = true;
            for (var i = 0; i < args.Length; i++)
            {
                if (bool.Parse(Evaluations[i].ToString()) == args[i]) continue;
                _result = false;
                break;
            }
            return this;
        }

        public IWhenElse<T> Then(Action action)
        {
            if(_result) action();
            return this;
        }

        public IWhen<T> Else(Action action)
        {
            if(!_result) action();
            return this;
        }
    }

    public static class EvaluateStatic
    {
        public static Evaluate<T> Eval<T>(params T[] args)
        {
            return new Evaluate<T>(args);
        }
    }
}