﻿// -----------------------------------------------------------------------
// Copyright © 2012 Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Lightweight.Hosting.Core;
using System.ComponentModel.Composition.Lightweight.Hosting.Providers.TypedParts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel.Composition.Lightweight.Hosting.Providers.TypedParts.ActivationFeatures
{
    /// <summary>
    /// Modifies activators of parts that implement <see cref="IPartImportsSatisfiedNotification"/> so that
    /// their OnImportsSatisfied() method is correctly called.
    /// </summary>
    class PisnFeature : ActivationFeature
    {
        public override CompositeActivator RewriteActivator(
            Type partType,
            CompositeActivator activator,
            IDictionary<string, object> partMetadata,
            Dependency[] dependencies)
        {
            if (!typeof(IPartImportsSatisfiedNotification).IsAssignableFrom(partType))
                return activator;

            return (c, o) =>
            {
                var ipisn = (IPartImportsSatisfiedNotification)activator(c, o);
                o.AddPostCompositionAction(ipisn.OnImportsSatisfied);
                return ipisn;
            };
        }
    }
}
