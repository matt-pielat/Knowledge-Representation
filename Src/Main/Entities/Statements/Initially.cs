﻿using KR.Main.Entities.Conditions;

namespace KR.Main.Entities.Statements
{
    /// <summary>
    /// Sentence class that represents initially clause.
    /// </summary>
    public class Initially
    {
        public ICondition Condition { get; private set; }

        /// <summary>
        /// Creates instance of initially sentence for given condition.
        /// </summary>
        /// <param name="condition">condition for sentence</param>
        public Initially(ICondition condition)
        {
            Condition = condition ?? new True();
        }

        public override string ToString()
        {
            return "initially " + Condition.ToString();               
        }
    }
}
