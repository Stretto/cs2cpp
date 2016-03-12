﻿namespace Il2Native.Logic.DOM.Synthesized
{
    using System;
    using System.Collections.Immutable;
    using DOM2;
    using Implementations;
    using Microsoft.CodeAnalysis;

    public class CCodeCloneVirtualMethod : CCodeMethodDeclaration
    {
        public CCodeCloneVirtualMethod(INamedTypeSymbol type)
            : base(new CCodeCloneMethod(type))
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            MethodBodyOpt = new MethodBody(Method)
            {
                Statements =
                {
                    new ReturnStatement()
                    {
                        ExpressionOpt =
                            new ObjectCreationExpression
                            {
                                Type = type,
                                NewOperator = true,
                                Arguments = { new PointerIndirectionOperator { Operand = new ThisReference() } }
                            }
                    }
                }
            };
        }

        public class CCodeCloneMethod : MethodImpl
        {
            public CCodeCloneMethod(INamedTypeSymbol type)
            {
                Name = "__clone";
                MetadataName = Name;
                MethodKind = MethodKind.Ordinary;
                ContainingType = type;
                IsVirtual = true;
                IsOverride = type.BaseType != null;
                ReturnType = GetReturnType(type);
                Parameters = ImmutableArray<IParameterSymbol>.Empty;
            }

            private static INamedTypeSymbol GetReturnType(INamedTypeSymbol type)
            {
                return new NamedTypeImpl { SpecialType = SpecialType.System_Object };
                /*
                return type.IsValueType || type.TypeKind == TypeKind.Struct ||
                       type.TypeKind == TypeKind.Enum
                           ? (INamedTypeSymbol)new ValueTypeAsClassTypeImpl(type)
                           : type;
                */ 
            }
        }
    }
}