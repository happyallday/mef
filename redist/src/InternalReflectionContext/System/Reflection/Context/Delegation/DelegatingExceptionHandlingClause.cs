﻿// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Diagnostics.Contracts;

namespace System.Reflection.Context.Delegation
{
    internal class DelegatingExceptionHandlingClause : ExceptionHandlingClause
    {
        private readonly ExceptionHandlingClause _clause;

        public DelegatingExceptionHandlingClause(ExceptionHandlingClause clause)
        {
            Contract.Requires(clause != null);

            _clause = clause;
        }

        public override Type CatchType
        {
            get { return _clause.CatchType; }
        }

        public override int FilterOffset
        {
            get { return _clause.FilterOffset; }
        }

        public override ExceptionHandlingClauseOptions Flags
        {
            get { return _clause.Flags; }
        }

        public override int HandlerLength
        {
            get { return _clause.HandlerLength; }
        }

        public override int HandlerOffset
        {
            get { return _clause.HandlerOffset; }
        }

        public override int TryLength
        {
            get { return _clause.TryLength; }
        }

        public override int TryOffset
        {
            get { return _clause.TryOffset; }
        }

        public override string ToString()
        {
            return _clause.ToString();
        }
    }
}
