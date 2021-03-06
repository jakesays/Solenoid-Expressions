// $ANTLR 2.7.6 (2005-12-22): "Expression.g" -> "ExpressionParser.cs"$

namespace Solenoid.Expressions.Parser
{
	// Generate the header common to all output files.
	using System;
	
	using TokenBuffer              = antlr.TokenBuffer;
	using TokenStreamException     = antlr.TokenStreamException;
	using TokenStreamIOException   = antlr.TokenStreamIOException;
	using ANTLRException           = antlr.ANTLRException;
	using LLkParser = antlr.LLkParser;
	using Token                    = antlr.Token;
	using IToken                   = antlr.IToken;
	using TokenStream              = antlr.TokenStream;
	using RecognitionException     = antlr.RecognitionException;
	using NoViableAltException     = antlr.NoViableAltException;
	using MismatchedTokenException = antlr.MismatchedTokenException;
	using SemanticException        = antlr.SemanticException;
	using ParserSharedInputState   = antlr.ParserSharedInputState;
	using BitSet                   = antlr.collections.impl.BitSet;
	using AST                      = antlr.collections.AST;
	using ASTPair                  = antlr.ASTPair;
	using ASTFactory               = antlr.ASTFactory;
	using ASTArray                 = antlr.collections.impl.ASTArray;
	
	internal 	class ExpressionParser : antlr.LLkParser
	{
		public const int EOF = 1;
		public const int NULL_TREE_LOOKAHEAD = 3;
		public const int EXPR = 4;
		public const int OPERAND = 5;
		public const int FALSE = 6;
		public const int TRUE = 7;
		public const int AND = 8;
		public const int OR = 9;
		public const int XOR = 10;
		public const int IN = 11;
		public const int IS = 12;
		public const int BETWEEN = 13;
		public const int LIKE = 14;
		public const int MATCHES = 15;
		public const int NULL_LITERAL = 16;
		public const int LPAREN = 17;
		public const int SEMI = 18;
		public const int RPAREN = 19;
		public const int ASSIGN = 20;
		public const int DEFAULT = 21;
		public const int QMARK = 22;
		public const int COLON = 23;
		public const int PLUS = 24;
		public const int MINUS = 25;
		public const int STAR = 26;
		public const int DIV = 27;
		public const int MOD = 28;
		public const int POWER = 29;
		public const int BANG = 30;
		public const int DOT = 31;
		public const int POUND = 32;
		public const int ID = 33;
		public const int DOLLAR = 34;
		public const int COMMA = 35;
		public const int AT = 36;
		public const int LBRACKET = 37;
		public const int RBRACKET = 38;
		public const int PROJECT = 39;
		public const int RCURLY = 40;
		public const int SELECT = 41;
		public const int SELECT_FIRST = 42;
		public const int SELECT_LAST = 43;
		public const int TYPE = 44;
		public const int QUOTE = 45;
		public const int STRING_LITERAL = 46;
		public const int LAMBDA = 47;
		public const int PIPE = 48;
		public const int LITERAL_new = 49;
		public const int LCURLY = 50;
		public const int INTEGER_LITERAL = 51;
		public const int HEXADECIMAL_INTEGER_LITERAL = 52;
		public const int REAL_LITERAL = 53;
		public const int EQUAL = 54;
		public const int NOT_EQUAL = 55;
		public const int LESS_THAN = 56;
		public const int LESS_THAN_OR_EQUAL = 57;
		public const int GREATER_THAN = 58;
		public const int GREATER_THAN_OR_EQUAL = 59;
		public const int WS = 60;
		public const int BACKTICK = 61;
		public const int BACKSLASH = 62;
		public const int DOT_ESCAPED = 63;
		public const int APOS = 64;
		public const int NUMERIC_LITERAL = 65;
		public const int DECIMAL_DIGIT = 66;
		public const int INTEGER_TYPE_SUFFIX = 67;
		public const int HEX_DIGIT = 68;
		public const int EXPONENT_PART = 69;
		public const int SIGN = 70;
		public const int REAL_TYPE_SUFFIX = 71;
		
		
    // CLOVER:OFF
    
    public override void reportError(RecognitionException ex)
    {
		//base.reportError(ex);
        throw new antlr.TokenStreamRecognitionException(ex);
    }

    public override void reportError(string error)
    {
		//base.reportError(error);
        throw new RecognitionException(error);
    }
    
    private string GetRelationalOperatorNodeType(string op)
    {
        switch (op)
        {
            case "==" : return "Solenoid.Expressions.OpEqual";
            case "!=" : return "Solenoid.Expressions.OpNotEqual";
            case "<" : return "Solenoid.Expressions.OpLess";
            case "<=" : return "Solenoid.Expressions.OpLessOrEqual";
            case ">" : return "Solenoid.Expressions.OpGreater";
            case ">=" : return "Solenoid.Expressions.OpGreaterOrEqual";
            case "in" : return "Solenoid.Expressions.OpIn";
            case "is" : return "Solenoid.Expressions.OpIs";
            case "between" : return "Solenoid.Expressions.OpBetween";
            case "like" : return "Solenoid.Expressions.OpLike";
            case "matches" : return "Solenoid.Expressions.OpMatches";
            default : 
                throw new ArgumentException("Node type for operator '" + op + "' is not defined.");
        }
    }
		
		protected void initialize()
		{
			tokenNames = tokenNames_;
			initializeFactory();
		}
		
		
		protected ExpressionParser(TokenBuffer tokenBuf, int k) : base(tokenBuf, k)
		{
			initialize();
		}
		
		public ExpressionParser(TokenBuffer tokenBuf) : this(tokenBuf,2)
		{
		}
		
		protected ExpressionParser(TokenStream lexer, int k) : base(lexer,k)
		{
			initialize();
		}
		
		public ExpressionParser(TokenStream lexer) : this(lexer,2)
		{
		}
		
		public ExpressionParser(ParserSharedInputState state) : base(state,2)
		{
			initialize();
		}
		
	public void expr() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode expr_AST = null;
		
		try {      // for error handling
			expression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			match(Token.EOF_TYPE);
			expr_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_0_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = expr_AST;
	}
	
	public void expression() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode expression_AST = null;
		
		try {      // for error handling
			logicalOrExpression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{
				switch ( LA(1) )
				{
				case ASSIGN:
				{
					{
						Solenoid.Expressions.AssignNode tmp2_AST = null;
						tmp2_AST = (Solenoid.Expressions.AssignNode) astFactory.create(LT(1), "Solenoid.Expressions.AssignNode");
						astFactory.makeASTRoot(ref currentAST, (AST)tmp2_AST);
						match(ASSIGN);
						logicalOrExpression();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					break;
				}
				case DEFAULT:
				{
					{
						Solenoid.Expressions.DefaultNode tmp3_AST = null;
						tmp3_AST = (Solenoid.Expressions.DefaultNode) astFactory.create(LT(1), "Solenoid.Expressions.DefaultNode");
						astFactory.makeASTRoot(ref currentAST, (AST)tmp3_AST);
						match(DEFAULT);
						logicalOrExpression();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					break;
				}
				case QMARK:
				{
					{
						Solenoid.Expressions.TernaryNode tmp4_AST = null;
						tmp4_AST = (Solenoid.Expressions.TernaryNode) astFactory.create(LT(1), "Solenoid.Expressions.TernaryNode");
						astFactory.makeASTRoot(ref currentAST, (AST)tmp4_AST);
						match(QMARK);
						expression();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
						match(COLON);
						expression();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					break;
				}
				case EOF:
				case SEMI:
				case RPAREN:
				case COLON:
				case COMMA:
				case RBRACKET:
				case RCURLY:
				{
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			expression_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_1_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = expression_AST;
	}
	
	public void exprList() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode exprList_AST = null;
		
		try {      // for error handling
			match(LPAREN);
			expression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{ // ( ... )+
				int _cnt4=0;
				for (;;)
				{
					if ((LA(1)==SEMI))
					{
						match(SEMI);
						expression();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else
					{
						if (_cnt4 >= 1) { goto _loop4_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
					}
					
					_cnt4++;
				}
_loop4_breakloop:				;
			}    // ( ... )+
			match(RPAREN);
			if (0==inputState.guessing)
			{
				exprList_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				exprList_AST = (Solenoid.Expressions.SerializableNode) astFactory.make((AST)(Solenoid.Expressions.SerializableNode) astFactory.create(EXPR,"expressionList","Solenoid.Expressions.ExpressionListNode"), (AST)exprList_AST);
				currentAST.root = exprList_AST;
				if ( (null != exprList_AST) && (null != exprList_AST.getFirstChild()) )
					currentAST.child = exprList_AST.getFirstChild();
				else
					currentAST.child = exprList_AST;
				currentAST.advanceChildToEnd();
			}
			exprList_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = exprList_AST;
	}
	
	public void logicalOrExpression() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode logicalOrExpression_AST = null;
		
		try {      // for error handling
			logicalXorExpression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==OR))
					{
						Solenoid.Expressions.OpOr tmp9_AST = null;
						tmp9_AST = (Solenoid.Expressions.OpOr) astFactory.create(LT(1), "Solenoid.Expressions.OpOr");
						astFactory.makeASTRoot(ref currentAST, (AST)tmp9_AST);
						match(OR);
						logicalXorExpression();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else
					{
						goto _loop13_breakloop;
					}
					
				}
_loop13_breakloop:				;
			}    // ( ... )*
			logicalOrExpression_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_3_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = logicalOrExpression_AST;
	}
	
	public void parenExpr() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode parenExpr_AST = null;
		
		try {      // for error handling
			match(LPAREN);
			expression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			match(RPAREN);
			parenExpr_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = parenExpr_AST;
	}
	
	public void logicalXorExpression() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode logicalXorExpression_AST = null;
		
		try {      // for error handling
			logicalAndExpression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==XOR))
					{
						Solenoid.Expressions.OpXor tmp12_AST = null;
						tmp12_AST = (Solenoid.Expressions.OpXor) astFactory.create(LT(1), "Solenoid.Expressions.OpXor");
						astFactory.makeASTRoot(ref currentAST, (AST)tmp12_AST);
						match(XOR);
						logicalAndExpression();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else
					{
						goto _loop16_breakloop;
					}
					
				}
_loop16_breakloop:				;
			}    // ( ... )*
			logicalXorExpression_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = logicalXorExpression_AST;
	}
	
	public void logicalAndExpression() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode logicalAndExpression_AST = null;
		
		try {      // for error handling
			relationalExpression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==AND))
					{
						Solenoid.Expressions.OpAnd tmp13_AST = null;
						tmp13_AST = (Solenoid.Expressions.OpAnd) astFactory.create(LT(1), "Solenoid.Expressions.OpAnd");
						astFactory.makeASTRoot(ref currentAST, (AST)tmp13_AST);
						match(AND);
						relationalExpression();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else
					{
						goto _loop19_breakloop;
					}
					
				}
_loop19_breakloop:				;
			}    // ( ... )*
			logicalAndExpression_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_5_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = logicalAndExpression_AST;
	}
	
	public void relationalExpression() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode relationalExpression_AST = null;
		Solenoid.Expressions.SerializableNode e1_AST = null;
		Solenoid.Expressions.SerializableNode op_AST = null;
		Solenoid.Expressions.SerializableNode e2_AST = null;
		
		try {      // for error handling
			sumExpr();
			if (0 == inputState.guessing)
			{
				e1_AST = (Solenoid.Expressions.SerializableNode)returnAST;
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{
				if ((tokenSet_6_.member(LA(1))))
				{
					relationalOperator();
					if (0 == inputState.guessing)
					{
						op_AST = (Solenoid.Expressions.SerializableNode)returnAST;
					}
					sumExpr();
					if (0 == inputState.guessing)
					{
						e2_AST = (Solenoid.Expressions.SerializableNode)returnAST;
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					if (0==inputState.guessing)
					{
						relationalExpression_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
						relationalExpression_AST = (Solenoid.Expressions.SerializableNode) astFactory.make((AST)(Solenoid.Expressions.SerializableNode) astFactory.create(EXPR,op_AST.getText(),GetRelationalOperatorNodeType(op_AST.getText())), (AST)relationalExpression_AST);
						currentAST.root = relationalExpression_AST;
						if ( (null != relationalExpression_AST) && (null != relationalExpression_AST.getFirstChild()) )
							currentAST.child = relationalExpression_AST.getFirstChild();
						else
							currentAST.child = relationalExpression_AST;
						currentAST.advanceChildToEnd();
					}
				}
				else if ((tokenSet_7_.member(LA(1)))) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			relationalExpression_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_7_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = relationalExpression_AST;
	}
	
	public void sumExpr() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode sumExpr_AST = null;
		
		try {      // for error handling
			prodExpr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==PLUS||LA(1)==MINUS))
					{
						{
							if ((LA(1)==PLUS))
							{
								Solenoid.Expressions.OpAdd tmp14_AST = null;
								tmp14_AST = (Solenoid.Expressions.OpAdd) astFactory.create(LT(1), "Solenoid.Expressions.OpAdd");
								astFactory.makeASTRoot(ref currentAST, (AST)tmp14_AST);
								match(PLUS);
							}
							else if ((LA(1)==MINUS)) {
								Solenoid.Expressions.OpSubtract tmp15_AST = null;
								tmp15_AST = (Solenoid.Expressions.OpSubtract) astFactory.create(LT(1), "Solenoid.Expressions.OpSubtract");
								astFactory.makeASTRoot(ref currentAST, (AST)tmp15_AST);
								match(MINUS);
							}
							else
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							
						}
						prodExpr();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else
					{
						goto _loop25_breakloop;
					}
					
				}
_loop25_breakloop:				;
			}    // ( ... )*
			sumExpr_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_8_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = sumExpr_AST;
	}
	
	public void relationalOperator() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode relationalOperator_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case EQUAL:
			{
				Solenoid.Expressions.SerializableNode tmp16_AST = null;
				tmp16_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp16_AST);
				match(EQUAL);
				relationalOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case NOT_EQUAL:
			{
				Solenoid.Expressions.SerializableNode tmp17_AST = null;
				tmp17_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp17_AST);
				match(NOT_EQUAL);
				relationalOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case LESS_THAN:
			{
				Solenoid.Expressions.SerializableNode tmp18_AST = null;
				tmp18_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp18_AST);
				match(LESS_THAN);
				relationalOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case LESS_THAN_OR_EQUAL:
			{
				Solenoid.Expressions.SerializableNode tmp19_AST = null;
				tmp19_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp19_AST);
				match(LESS_THAN_OR_EQUAL);
				relationalOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case GREATER_THAN:
			{
				Solenoid.Expressions.SerializableNode tmp20_AST = null;
				tmp20_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp20_AST);
				match(GREATER_THAN);
				relationalOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case GREATER_THAN_OR_EQUAL:
			{
				Solenoid.Expressions.SerializableNode tmp21_AST = null;
				tmp21_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp21_AST);
				match(GREATER_THAN_OR_EQUAL);
				relationalOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case IN:
			{
				Solenoid.Expressions.SerializableNode tmp22_AST = null;
				tmp22_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp22_AST);
				match(IN);
				relationalOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case IS:
			{
				Solenoid.Expressions.SerializableNode tmp23_AST = null;
				tmp23_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp23_AST);
				match(IS);
				relationalOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case BETWEEN:
			{
				Solenoid.Expressions.SerializableNode tmp24_AST = null;
				tmp24_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp24_AST);
				match(BETWEEN);
				relationalOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case LIKE:
			{
				Solenoid.Expressions.SerializableNode tmp25_AST = null;
				tmp25_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp25_AST);
				match(LIKE);
				relationalOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case MATCHES:
			{
				Solenoid.Expressions.SerializableNode tmp26_AST = null;
				tmp26_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp26_AST);
				match(MATCHES);
				relationalOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_9_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = relationalOperator_AST;
	}
	
	public void prodExpr() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode prodExpr_AST = null;
		
		try {      // for error handling
			powExpr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if (((LA(1) >= STAR && LA(1) <= MOD)))
					{
						{
							switch ( LA(1) )
							{
							case STAR:
							{
								Solenoid.Expressions.OpMultiply tmp27_AST = null;
								tmp27_AST = (Solenoid.Expressions.OpMultiply) astFactory.create(LT(1), "Solenoid.Expressions.OpMultiply");
								astFactory.makeASTRoot(ref currentAST, (AST)tmp27_AST);
								match(STAR);
								break;
							}
							case DIV:
							{
								Solenoid.Expressions.OpDivide tmp28_AST = null;
								tmp28_AST = (Solenoid.Expressions.OpDivide) astFactory.create(LT(1), "Solenoid.Expressions.OpDivide");
								astFactory.makeASTRoot(ref currentAST, (AST)tmp28_AST);
								match(DIV);
								break;
							}
							case MOD:
							{
								Solenoid.Expressions.OpModulous tmp29_AST = null;
								tmp29_AST = (Solenoid.Expressions.OpModulous) astFactory.create(LT(1), "Solenoid.Expressions.OpModulous");
								astFactory.makeASTRoot(ref currentAST, (AST)tmp29_AST);
								match(MOD);
								break;
							}
							default:
							{
								throw new NoViableAltException(LT(1), getFilename());
							}
							 }
						}
						powExpr();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else
					{
						goto _loop29_breakloop;
					}
					
				}
_loop29_breakloop:				;
			}    // ( ... )*
			prodExpr_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_10_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = prodExpr_AST;
	}
	
	public void powExpr() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode powExpr_AST = null;
		
		try {      // for error handling
			unaryExpression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{
				if ((LA(1)==POWER))
				{
					Solenoid.Expressions.OpPower tmp30_AST = null;
					tmp30_AST = (Solenoid.Expressions.OpPower) astFactory.create(LT(1), "Solenoid.Expressions.OpPower");
					astFactory.makeASTRoot(ref currentAST, (AST)tmp30_AST);
					match(POWER);
					unaryExpression();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
				}
				else if ((tokenSet_11_.member(LA(1)))) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			powExpr_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_11_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = powExpr_AST;
	}
	
	public void unaryExpression() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode unaryExpression_AST = null;
		
		try {      // for error handling
			if ((LA(1)==PLUS||LA(1)==MINUS||LA(1)==BANG))
			{
				{
					switch ( LA(1) )
					{
					case PLUS:
					{
						Solenoid.Expressions.OpUnaryPlus tmp31_AST = null;
						tmp31_AST = (Solenoid.Expressions.OpUnaryPlus) astFactory.create(LT(1), "Solenoid.Expressions.OpUnaryPlus");
						astFactory.makeASTRoot(ref currentAST, (AST)tmp31_AST);
						match(PLUS);
						break;
					}
					case MINUS:
					{
						Solenoid.Expressions.OpUnaryMinus tmp32_AST = null;
						tmp32_AST = (Solenoid.Expressions.OpUnaryMinus) astFactory.create(LT(1), "Solenoid.Expressions.OpUnaryMinus");
						astFactory.makeASTRoot(ref currentAST, (AST)tmp32_AST);
						match(MINUS);
						break;
					}
					case BANG:
					{
						Solenoid.Expressions.OpNot tmp33_AST = null;
						tmp33_AST = (Solenoid.Expressions.OpNot) astFactory.create(LT(1), "Solenoid.Expressions.OpNot");
						astFactory.makeASTRoot(ref currentAST, (AST)tmp33_AST);
						match(BANG);
						break;
					}
					default:
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					 }
				}
				unaryExpression();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				unaryExpression_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else if ((tokenSet_12_.member(LA(1)))) {
				primaryExpression();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				unaryExpression_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_13_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = unaryExpression_AST;
	}
	
	public void primaryExpression() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode primaryExpression_AST = null;
		
		try {      // for error handling
			startNode();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{
				if ((tokenSet_14_.member(LA(1))))
				{
					node();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
				}
				else if ((tokenSet_13_.member(LA(1)))) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			if (0==inputState.guessing)
			{
				primaryExpression_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				primaryExpression_AST = (Solenoid.Expressions.SerializableNode) astFactory.make((AST)(Solenoid.Expressions.SerializableNode) astFactory.create(EXPR,"expression","Solenoid.Expressions.Expression"), (AST)primaryExpression_AST);
				currentAST.root = primaryExpression_AST;
				if ( (null != primaryExpression_AST) && (null != primaryExpression_AST.getFirstChild()) )
					currentAST.child = primaryExpression_AST.getFirstChild();
				else
					currentAST.child = primaryExpression_AST;
				currentAST.advanceChildToEnd();
			}
			primaryExpression_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_13_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = primaryExpression_AST;
	}
	
	public void unaryOperator() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode unaryOperator_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case PLUS:
			{
				Solenoid.Expressions.SerializableNode tmp34_AST = null;
				tmp34_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp34_AST);
				match(PLUS);
				unaryOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case MINUS:
			{
				Solenoid.Expressions.SerializableNode tmp35_AST = null;
				tmp35_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp35_AST);
				match(MINUS);
				unaryOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case BANG:
			{
				Solenoid.Expressions.SerializableNode tmp36_AST = null;
				tmp36_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp36_AST);
				match(BANG);
				unaryOperator_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_0_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = unaryOperator_AST;
	}
	
	public void startNode() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode startNode_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case ID:
				{
					methodOrProperty();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					break;
				}
				case DOLLAR:
				{
					localFunctionOrVar();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					break;
				}
				case LBRACKET:
				{
					indexer();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					break;
				}
				case FALSE:
				case TRUE:
				case NULL_LITERAL:
				case STRING_LITERAL:
				case INTEGER_LITERAL:
				case HEXADECIMAL_INTEGER_LITERAL:
				case REAL_LITERAL:
				{
					literal();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					break;
				}
				case TYPE:
				{
					type();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					break;
				}
				case LITERAL_new:
				{
					constructor();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					break;
				}
				case PROJECT:
				{
					projection();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					break;
				}
				case SELECT:
				{
					selection();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					break;
				}
				case SELECT_FIRST:
				{
					firstSelection();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					break;
				}
				case SELECT_LAST:
				{
					lastSelection();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					break;
				}
				case LCURLY:
				{
					listInitializer();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					break;
				}
				case LAMBDA:
				{
					lambda();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					break;
				}
				default:
					bool synPredMatched40 = false;
					if (((LA(1)==LPAREN) && (tokenSet_9_.member(LA(2)))))
					{
						int _m40 = mark();
						synPredMatched40 = true;
						inputState.guessing++;
						try {
							{
								match(LPAREN);
								expression();
								match(SEMI);
							}
						}
						catch (RecognitionException)
						{
							synPredMatched40 = false;
						}
						rewind(_m40);
						inputState.guessing--;
					}
					if ( synPredMatched40 )
					{
						exprList();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else if ((LA(1)==LPAREN) && (tokenSet_9_.member(LA(2)))) {
						parenExpr();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else if ((LA(1)==POUND) && (LA(2)==ID)) {
						functionOrVar();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else if ((LA(1)==AT) && (LA(2)==LPAREN)) {
						reference();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else if ((LA(1)==POUND) && (LA(2)==LCURLY)) {
						mapInitializer();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else if ((LA(1)==AT) && (LA(2)==LBRACKET)) {
						attribute();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				break; }
			}
			startNode_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = startNode_AST;
	}
	
	public void node() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode node_AST = null;
		
		try {      // for error handling
			{ // ( ... )+
				int _cnt43=0;
				for (;;)
				{
					switch ( LA(1) )
					{
					case ID:
					{
						methodOrProperty();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
						break;
					}
					case LBRACKET:
					{
						indexer();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
						break;
					}
					case PROJECT:
					{
						projection();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
						break;
					}
					case SELECT:
					{
						selection();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
						break;
					}
					case SELECT_FIRST:
					{
						firstSelection();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
						break;
					}
					case SELECT_LAST:
					{
						lastSelection();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
						break;
					}
					case LPAREN:
					{
						exprList();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
						break;
					}
					case DOT:
					{
						match(DOT);
						break;
					}
					default:
					{
						if (_cnt43 >= 1) { goto _loop43_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
					}
					break; }
					_cnt43++;
				}
_loop43_breakloop:				;
			}    // ( ... )+
			node_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_13_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = node_AST;
	}
	
	public void methodOrProperty() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode methodOrProperty_AST = null;
		
		try {      // for error handling
			bool synPredMatched56 = false;
			if (((LA(1)==ID) && (LA(2)==LPAREN)))
			{
				int _m56 = mark();
				synPredMatched56 = true;
				inputState.guessing++;
				try {
					{
						match(ID);
						match(LPAREN);
					}
				}
				catch (RecognitionException)
				{
					synPredMatched56 = false;
				}
				rewind(_m56);
				inputState.guessing--;
			}
			if ( synPredMatched56 )
			{
				Solenoid.Expressions.MethodNode tmp38_AST = null;
				tmp38_AST = (Solenoid.Expressions.MethodNode) astFactory.create(LT(1), "Solenoid.Expressions.MethodNode");
				astFactory.makeASTRoot(ref currentAST, (AST)tmp38_AST);
				match(ID);
				methodArgs();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				methodOrProperty_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else if ((LA(1)==ID) && (tokenSet_2_.member(LA(2)))) {
				property();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				methodOrProperty_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = methodOrProperty_AST;
	}
	
	public void functionOrVar() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode functionOrVar_AST = null;
		
		try {      // for error handling
			bool synPredMatched46 = false;
			if (((LA(1)==POUND) && (LA(2)==ID)))
			{
				int _m46 = mark();
				synPredMatched46 = true;
				inputState.guessing++;
				try {
					{
						match(POUND);
						match(ID);
						match(LPAREN);
					}
				}
				catch (RecognitionException)
				{
					synPredMatched46 = false;
				}
				rewind(_m46);
				inputState.guessing--;
			}
			if ( synPredMatched46 )
			{
				function();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				functionOrVar_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else if ((LA(1)==POUND) && (LA(2)==ID)) {
				var();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				functionOrVar_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = functionOrVar_AST;
	}
	
	public void localFunctionOrVar() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode localFunctionOrVar_AST = null;
		
		try {      // for error handling
			bool synPredMatched51 = false;
			if (((LA(1)==DOLLAR) && (LA(2)==ID)))
			{
				int _m51 = mark();
				synPredMatched51 = true;
				inputState.guessing++;
				try {
					{
						match(DOLLAR);
						match(ID);
						match(LPAREN);
					}
				}
				catch (RecognitionException)
				{
					synPredMatched51 = false;
				}
				rewind(_m51);
				inputState.guessing--;
			}
			if ( synPredMatched51 )
			{
				localFunction();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				localFunctionOrVar_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else if ((LA(1)==DOLLAR) && (LA(2)==ID)) {
				localVar();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				localFunctionOrVar_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = localFunctionOrVar_AST;
	}
	
	public void reference() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode reference_AST = null;
		Solenoid.Expressions.SerializableNode cn_AST = null;
		Solenoid.Expressions.SerializableNode id_AST = null;
		Solenoid.Expressions.SerializableNode localid_AST = null;
		
		try {      // for error handling
			bool synPredMatched64 = false;
			if (((LA(1)==AT) && (LA(2)==LPAREN)))
			{
				int _m64 = mark();
				synPredMatched64 = true;
				inputState.guessing++;
				try {
					{
						match(AT);
						match(LPAREN);
						quotableName();
						match(COLON);
					}
				}
				catch (RecognitionException)
				{
					synPredMatched64 = false;
				}
				rewind(_m64);
				inputState.guessing--;
			}
			if ( synPredMatched64 )
			{
				match(AT);
				match(LPAREN);
				quotableName();
				if (0 == inputState.guessing)
				{
					cn_AST = (Solenoid.Expressions.SerializableNode)returnAST;
				}
				match(COLON);
				quotableName();
				if (0 == inputState.guessing)
				{
					id_AST = (Solenoid.Expressions.SerializableNode)returnAST;
				}
				match(RPAREN);
				if (0==inputState.guessing)
				{
					reference_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
					reference_AST = (Solenoid.Expressions.SerializableNode) astFactory.make((AST)(Solenoid.Expressions.SerializableNode) astFactory.create(EXPR,"ref","Spring.Context.Support.ReferenceNode"), (AST)cn_AST, (AST)id_AST);
					currentAST.root = reference_AST;
					if ( (null != reference_AST) && (null != reference_AST.getFirstChild()) )
						currentAST.child = reference_AST.getFirstChild();
					else
						currentAST.child = reference_AST;
					currentAST.advanceChildToEnd();
				}
				reference_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else if ((LA(1)==AT) && (LA(2)==LPAREN)) {
				match(AT);
				match(LPAREN);
				quotableName();
				if (0 == inputState.guessing)
				{
					localid_AST = (Solenoid.Expressions.SerializableNode)returnAST;
				}
				match(RPAREN);
				if (0==inputState.guessing)
				{
					reference_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
					reference_AST = (Solenoid.Expressions.SerializableNode) astFactory.make((AST)(Solenoid.Expressions.SerializableNode) astFactory.create(EXPR,"ref","Spring.Context.Support.ReferenceNode"), (AST)null, (AST)localid_AST);
					currentAST.root = reference_AST;
					if ( (null != reference_AST) && (null != reference_AST.getFirstChild()) )
						currentAST.child = reference_AST.getFirstChild();
					else
						currentAST.child = reference_AST;
					currentAST.advanceChildToEnd();
				}
				reference_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = reference_AST;
	}
	
	public void indexer() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode indexer_AST = null;
		
		try {      // for error handling
			Solenoid.Expressions.IndexerNode tmp46_AST = null;
			tmp46_AST = (Solenoid.Expressions.IndexerNode) astFactory.create(LT(1), "Solenoid.Expressions.IndexerNode");
			astFactory.makeASTRoot(ref currentAST, (AST)tmp46_AST);
			match(LBRACKET);
			argument();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						match(COMMA);
						argument();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else
					{
						goto _loop67_breakloop;
					}
					
				}
_loop67_breakloop:				;
			}    // ( ... )*
			match(RBRACKET);
			indexer_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = indexer_AST;
	}
	
	public void literal() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode literal_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case NULL_LITERAL:
			{
				Solenoid.Expressions.NullLiteralNode tmp49_AST = null;
				tmp49_AST = (Solenoid.Expressions.NullLiteralNode) astFactory.create(LT(1), "Solenoid.Expressions.NullLiteralNode");
				astFactory.addASTChild(ref currentAST, (AST)tmp49_AST);
				match(NULL_LITERAL);
				literal_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case INTEGER_LITERAL:
			{
				Solenoid.Expressions.IntLiteralNode tmp50_AST = null;
				tmp50_AST = (Solenoid.Expressions.IntLiteralNode) astFactory.create(LT(1), "Solenoid.Expressions.IntLiteralNode");
				astFactory.addASTChild(ref currentAST, (AST)tmp50_AST);
				match(INTEGER_LITERAL);
				literal_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case HEXADECIMAL_INTEGER_LITERAL:
			{
				Solenoid.Expressions.HexLiteralNode tmp51_AST = null;
				tmp51_AST = (Solenoid.Expressions.HexLiteralNode) astFactory.create(LT(1), "Solenoid.Expressions.HexLiteralNode");
				astFactory.addASTChild(ref currentAST, (AST)tmp51_AST);
				match(HEXADECIMAL_INTEGER_LITERAL);
				literal_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case REAL_LITERAL:
			{
				Solenoid.Expressions.RealLiteralNode tmp52_AST = null;
				tmp52_AST = (Solenoid.Expressions.RealLiteralNode) astFactory.create(LT(1), "Solenoid.Expressions.RealLiteralNode");
				astFactory.addASTChild(ref currentAST, (AST)tmp52_AST);
				match(REAL_LITERAL);
				literal_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case STRING_LITERAL:
			{
				Solenoid.Expressions.StringLiteralNode tmp53_AST = null;
				tmp53_AST = (Solenoid.Expressions.StringLiteralNode) astFactory.create(LT(1), "Solenoid.Expressions.StringLiteralNode");
				astFactory.addASTChild(ref currentAST, (AST)tmp53_AST);
				match(STRING_LITERAL);
				literal_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			case FALSE:
			case TRUE:
			{
				boolLiteral();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				literal_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = literal_AST;
	}
	
	public void type() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode type_AST = null;
		Solenoid.Expressions.SerializableNode tn_AST = null;
		
		try {      // for error handling
			match(TYPE);
			name();
			if (0 == inputState.guessing)
			{
				tn_AST = (Solenoid.Expressions.SerializableNode)returnAST;
			}
			match(RPAREN);
			if (0==inputState.guessing)
			{
				type_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				type_AST = (Solenoid.Expressions.SerializableNode) astFactory.make((AST)(Solenoid.Expressions.SerializableNode) astFactory.create(EXPR,tn_AST.getText(),"Solenoid.Expressions.TypeNode"), (AST)type_AST);
				currentAST.root = type_AST;
				if ( (null != type_AST) && (null != type_AST.getFirstChild()) )
					currentAST.child = type_AST.getFirstChild();
				else
					currentAST.child = type_AST;
				currentAST.advanceChildToEnd();
			}
			type_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = type_AST;
	}
	
	public void constructor() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode constructor_AST = null;
		Solenoid.Expressions.SerializableNode type_AST = null;
		
		try {      // for error handling
			bool synPredMatched90 = false;
			if (((LA(1)==LITERAL_new) && (LA(2)==ID)))
			{
				int _m90 = mark();
				synPredMatched90 = true;
				inputState.guessing++;
				try {
					{
						match(LITERAL_new);
						qualifiedId();
						match(LPAREN);
					}
				}
				catch (RecognitionException)
				{
					synPredMatched90 = false;
				}
				rewind(_m90);
				inputState.guessing--;
			}
			if ( synPredMatched90 )
			{
				match(LITERAL_new);
				qualifiedId();
				if (0 == inputState.guessing)
				{
					type_AST = (Solenoid.Expressions.SerializableNode)returnAST;
				}
				ctorArgs();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				if (0==inputState.guessing)
				{
					constructor_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
					constructor_AST = (Solenoid.Expressions.SerializableNode) astFactory.make((AST)(Solenoid.Expressions.SerializableNode) astFactory.create(EXPR,type_AST.getText(),"Solenoid.Expressions.ConstructorNode"), (AST)constructor_AST);
					currentAST.root = constructor_AST;
					if ( (null != constructor_AST) && (null != constructor_AST.getFirstChild()) )
						currentAST.child = constructor_AST.getFirstChild();
					else
						currentAST.child = constructor_AST;
					currentAST.advanceChildToEnd();
				}
				constructor_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else if ((LA(1)==LITERAL_new) && (LA(2)==ID)) {
				arrayConstructor();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				constructor_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = constructor_AST;
	}
	
	public void projection() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode projection_AST = null;
		
		try {      // for error handling
			Solenoid.Expressions.ProjectionNode tmp57_AST = null;
			tmp57_AST = (Solenoid.Expressions.ProjectionNode) astFactory.create(LT(1), "Solenoid.Expressions.ProjectionNode");
			astFactory.makeASTRoot(ref currentAST, (AST)tmp57_AST);
			match(PROJECT);
			expression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			match(RCURLY);
			projection_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = projection_AST;
	}
	
	public void selection() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode selection_AST = null;
		
		try {      // for error handling
			Solenoid.Expressions.SelectionNode tmp59_AST = null;
			tmp59_AST = (Solenoid.Expressions.SelectionNode) astFactory.create(LT(1), "Solenoid.Expressions.SelectionNode");
			astFactory.makeASTRoot(ref currentAST, (AST)tmp59_AST);
			match(SELECT);
			expression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						match(COMMA);
						expression();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else
					{
						goto _loop71_breakloop;
					}
					
				}
_loop71_breakloop:				;
			}    // ( ... )*
			match(RCURLY);
			selection_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = selection_AST;
	}
	
	public void firstSelection() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode firstSelection_AST = null;
		
		try {      // for error handling
			Solenoid.Expressions.SelectionFirstNode tmp62_AST = null;
			tmp62_AST = (Solenoid.Expressions.SelectionFirstNode) astFactory.create(LT(1), "Solenoid.Expressions.SelectionFirstNode");
			astFactory.makeASTRoot(ref currentAST, (AST)tmp62_AST);
			match(SELECT_FIRST);
			expression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			match(RCURLY);
			firstSelection_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = firstSelection_AST;
	}
	
	public void lastSelection() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode lastSelection_AST = null;
		
		try {      // for error handling
			Solenoid.Expressions.SelectionLastNode tmp64_AST = null;
			tmp64_AST = (Solenoid.Expressions.SelectionLastNode) astFactory.create(LT(1), "Solenoid.Expressions.SelectionLastNode");
			astFactory.makeASTRoot(ref currentAST, (AST)tmp64_AST);
			match(SELECT_LAST);
			expression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			match(RCURLY);
			lastSelection_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = lastSelection_AST;
	}
	
	public void listInitializer() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode listInitializer_AST = null;
		
		try {      // for error handling
			Solenoid.Expressions.ListInitializerNode tmp66_AST = null;
			tmp66_AST = (Solenoid.Expressions.ListInitializerNode) astFactory.create(LT(1), "Solenoid.Expressions.ListInitializerNode");
			astFactory.makeASTRoot(ref currentAST, (AST)tmp66_AST);
			match(LCURLY);
			expression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						match(COMMA);
						expression();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else
					{
						goto _loop99_breakloop;
					}
					
				}
_loop99_breakloop:				;
			}    // ( ... )*
			match(RCURLY);
			listInitializer_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = listInitializer_AST;
	}
	
	public void mapInitializer() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode mapInitializer_AST = null;
		
		try {      // for error handling
			match(POUND);
			Solenoid.Expressions.MapInitializerNode tmp70_AST = null;
			tmp70_AST = (Solenoid.Expressions.MapInitializerNode) astFactory.create(LT(1), "Solenoid.Expressions.MapInitializerNode");
			astFactory.makeASTRoot(ref currentAST, (AST)tmp70_AST);
			match(LCURLY);
			mapEntry();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						match(COMMA);
						mapEntry();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(ref currentAST, (AST)returnAST);
						}
					}
					else
					{
						goto _loop102_breakloop;
					}
					
				}
_loop102_breakloop:				;
			}    // ( ... )*
			match(RCURLY);
			mapInitializer_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = mapInitializer_AST;
	}
	
	public void lambda() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode lambda_AST = null;
		
		try {      // for error handling
			match(LAMBDA);
			{
				if ((LA(1)==ID))
				{
					argList();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
				}
				else if ((LA(1)==PIPE)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			match(PIPE);
			expression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			match(RCURLY);
			if (0==inputState.guessing)
			{
				lambda_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				lambda_AST = (Solenoid.Expressions.SerializableNode) astFactory.make((AST)(Solenoid.Expressions.SerializableNode) astFactory.create(EXPR,"lambda","Solenoid.Expressions.LambdaExpressionNode"), (AST)lambda_AST);
				currentAST.root = lambda_AST;
				if ( (null != lambda_AST) && (null != lambda_AST.getFirstChild()) )
					currentAST.child = lambda_AST.getFirstChild();
				else
					currentAST.child = lambda_AST;
				currentAST.advanceChildToEnd();
			}
			lambda_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = lambda_AST;
	}
	
	public void attribute() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode attribute_AST = null;
		Solenoid.Expressions.SerializableNode tn_AST = null;
		
		try {      // for error handling
			match(AT);
			match(LBRACKET);
			qualifiedId();
			if (0 == inputState.guessing)
			{
				tn_AST = (Solenoid.Expressions.SerializableNode)returnAST;
			}
			{
				if ((LA(1)==LPAREN))
				{
					ctorArgs();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
				}
				else if ((LA(1)==RBRACKET)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			match(RBRACKET);
			if (0==inputState.guessing)
			{
				attribute_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				attribute_AST = (Solenoid.Expressions.SerializableNode) astFactory.make((AST)(Solenoid.Expressions.SerializableNode) astFactory.create(EXPR,tn_AST.getText(),"Solenoid.Expressions.AttributeNode"), (AST)attribute_AST);
				currentAST.root = attribute_AST;
				if ( (null != attribute_AST) && (null != attribute_AST.getFirstChild()) )
					currentAST.child = attribute_AST.getFirstChild();
				else
					currentAST.child = attribute_AST;
				currentAST.advanceChildToEnd();
			}
			attribute_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = attribute_AST;
	}
	
	public void function() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode function_AST = null;
		
		try {      // for error handling
			match(POUND);
			Solenoid.Expressions.FunctionNode tmp80_AST = null;
			tmp80_AST = (Solenoid.Expressions.FunctionNode) astFactory.create(LT(1), "Solenoid.Expressions.FunctionNode");
			astFactory.makeASTRoot(ref currentAST, (AST)tmp80_AST);
			match(ID);
			methodArgs();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			function_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = function_AST;
	}
	
	public void var() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode var_AST = null;
		
		try {      // for error handling
			match(POUND);
			Solenoid.Expressions.VariableNode tmp82_AST = null;
			tmp82_AST = (Solenoid.Expressions.VariableNode) astFactory.create(LT(1), "Solenoid.Expressions.VariableNode");
			astFactory.makeASTRoot(ref currentAST, (AST)tmp82_AST);
			match(ID);
			var_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = var_AST;
	}
	
	public void methodArgs() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode methodArgs_AST = null;
		
		try {      // for error handling
			match(LPAREN);
			{
				if ((tokenSet_9_.member(LA(1))))
				{
					argument();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					{    // ( ... )*
						for (;;)
						{
							if ((LA(1)==COMMA))
							{
								match(COMMA);
								argument();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, (AST)returnAST);
								}
							}
							else
							{
								goto _loop60_breakloop;
							}
							
						}
_loop60_breakloop:						;
					}    // ( ... )*
				}
				else if ((LA(1)==RPAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			match(RPAREN);
			methodArgs_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = methodArgs_AST;
	}
	
	public void localFunction() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode localFunction_AST = null;
		
		try {      // for error handling
			match(DOLLAR);
			Solenoid.Expressions.LocalFunctionNode tmp87_AST = null;
			tmp87_AST = (Solenoid.Expressions.LocalFunctionNode) astFactory.create(LT(1), "Solenoid.Expressions.LocalFunctionNode");
			astFactory.makeASTRoot(ref currentAST, (AST)tmp87_AST);
			match(ID);
			methodArgs();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			localFunction_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = localFunction_AST;
	}
	
	public void localVar() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode localVar_AST = null;
		
		try {      // for error handling
			match(DOLLAR);
			Solenoid.Expressions.LocalVariableNode tmp89_AST = null;
			tmp89_AST = (Solenoid.Expressions.LocalVariableNode) astFactory.create(LT(1), "Solenoid.Expressions.LocalVariableNode");
			astFactory.makeASTRoot(ref currentAST, (AST)tmp89_AST);
			match(ID);
			localVar_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = localVar_AST;
	}
	
	public void property() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode property_AST = null;
		
		try {      // for error handling
			Solenoid.Expressions.PropertyOrFieldNode tmp90_AST = null;
			tmp90_AST = (Solenoid.Expressions.PropertyOrFieldNode) astFactory.create(LT(1), "Solenoid.Expressions.PropertyOrFieldNode");
			astFactory.addASTChild(ref currentAST, (AST)tmp90_AST);
			match(ID);
			property_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = property_AST;
	}
	
	public void argument() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode argument_AST = null;
		
		try {      // for error handling
			expression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			argument_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_15_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = argument_AST;
	}
	
	public void quotableName() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode quotableName_AST = null;
		
		try {      // for error handling
			if ((LA(1)==STRING_LITERAL))
			{
				Solenoid.Expressions.QualifiedIdentifier tmp91_AST = null;
				tmp91_AST = (Solenoid.Expressions.QualifiedIdentifier) astFactory.create(LT(1), "Solenoid.Expressions.QualifiedIdentifier");
				astFactory.makeASTRoot(ref currentAST, (AST)tmp91_AST);
				match(STRING_LITERAL);
				quotableName_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else if ((LA(1)==ID)) {
				name();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				quotableName_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_16_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = quotableName_AST;
	}
	
	public void name() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode name_AST = null;
		
		try {      // for error handling
			Solenoid.Expressions.QualifiedIdentifier tmp92_AST = null;
			tmp92_AST = (Solenoid.Expressions.QualifiedIdentifier) astFactory.create(LT(1), "Solenoid.Expressions.QualifiedIdentifier");
			astFactory.makeASTRoot(ref currentAST, (AST)tmp92_AST);
			match(ID);
			{    // ( ... )*
				for (;;)
				{
					if ((tokenSet_17_.member(LA(1))))
					{
						{
							Solenoid.Expressions.SerializableNode tmp93_AST = null;
							tmp93_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, (AST)tmp93_AST);
							match(tokenSet_17_);
						}
					}
					else
					{
						goto _loop78_breakloop;
					}
					
				}
_loop78_breakloop:				;
			}    // ( ... )*
			name_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_16_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = name_AST;
	}
	
	public void qualifiedId() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode qualifiedId_AST = null;
		
		try {      // for error handling
			Solenoid.Expressions.QualifiedIdentifier tmp94_AST = null;
			tmp94_AST = (Solenoid.Expressions.QualifiedIdentifier) astFactory.create(LT(1), "Solenoid.Expressions.QualifiedIdentifier");
			astFactory.makeASTRoot(ref currentAST, (AST)tmp94_AST);
			match(ID);
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==DOT))
					{
						Solenoid.Expressions.SerializableNode tmp95_AST = null;
						tmp95_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, (AST)tmp95_AST);
						match(DOT);
						Solenoid.Expressions.SerializableNode tmp96_AST = null;
						tmp96_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
						astFactory.addASTChild(ref currentAST, (AST)tmp96_AST);
						match(ID);
					}
					else
					{
						goto _loop114_breakloop;
					}
					
				}
_loop114_breakloop:				;
			}    // ( ... )*
			qualifiedId_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_18_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = qualifiedId_AST;
	}
	
	public void ctorArgs() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode ctorArgs_AST = null;
		
		try {      // for error handling
			match(LPAREN);
			{
				if ((tokenSet_9_.member(LA(1))))
				{
					namedArgument();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					{    // ( ... )*
						for (;;)
						{
							if ((LA(1)==COMMA))
							{
								match(COMMA);
								namedArgument();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, (AST)returnAST);
								}
							}
							else
							{
								goto _loop107_breakloop;
							}
							
						}
_loop107_breakloop:						;
					}    // ( ... )*
				}
				else if ((LA(1)==RPAREN)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			match(RPAREN);
			ctorArgs_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = ctorArgs_AST;
	}
	
	public void argList() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode argList_AST = null;
		
		try {      // for error handling
			{
				Solenoid.Expressions.SerializableNode tmp100_AST = null;
				tmp100_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
				astFactory.addASTChild(ref currentAST, (AST)tmp100_AST);
				match(ID);
				{    // ( ... )*
					for (;;)
					{
						if ((LA(1)==COMMA))
						{
							match(COMMA);
							Solenoid.Expressions.SerializableNode tmp102_AST = null;
							tmp102_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
							astFactory.addASTChild(ref currentAST, (AST)tmp102_AST);
							match(ID);
						}
						else
						{
							goto _loop87_breakloop;
						}
						
					}
_loop87_breakloop:					;
				}    // ( ... )*
			}
			if (0==inputState.guessing)
			{
				argList_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				argList_AST = (Solenoid.Expressions.SerializableNode) astFactory.make((AST)(Solenoid.Expressions.SerializableNode) astFactory.create(EXPR,"args"), (AST)argList_AST);
				currentAST.root = argList_AST;
				if ( (null != argList_AST) && (null != argList_AST.getFirstChild()) )
					currentAST.child = argList_AST.getFirstChild();
				else
					currentAST.child = argList_AST;
				currentAST.advanceChildToEnd();
			}
			argList_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_19_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = argList_AST;
	}
	
	public void arrayConstructor() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode arrayConstructor_AST = null;
		Solenoid.Expressions.SerializableNode type_AST = null;
		
		try {      // for error handling
			match(LITERAL_new);
			qualifiedId();
			if (0 == inputState.guessing)
			{
				type_AST = (Solenoid.Expressions.SerializableNode)returnAST;
			}
			arrayRank();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			{
				if ((LA(1)==LCURLY))
				{
					listInitializer();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
				}
				else if ((tokenSet_2_.member(LA(1)))) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			if (0==inputState.guessing)
			{
				arrayConstructor_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				arrayConstructor_AST = (Solenoid.Expressions.SerializableNode) astFactory.make((AST)(Solenoid.Expressions.SerializableNode) astFactory.create(EXPR,type_AST.getText(),"Solenoid.Expressions.ArrayConstructorNode"), (AST)arrayConstructor_AST);
				currentAST.root = arrayConstructor_AST;
				if ( (null != arrayConstructor_AST) && (null != arrayConstructor_AST.getFirstChild()) )
					currentAST.child = arrayConstructor_AST.getFirstChild();
				else
					currentAST.child = arrayConstructor_AST;
				currentAST.advanceChildToEnd();
			}
			arrayConstructor_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = arrayConstructor_AST;
	}
	
	public void arrayRank() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode arrayRank_AST = null;
		
		try {      // for error handling
			Solenoid.Expressions.SerializableNode tmp104_AST = null;
			tmp104_AST = (Solenoid.Expressions.SerializableNode) astFactory.create(LT(1));
			astFactory.makeASTRoot(ref currentAST, (AST)tmp104_AST);
			match(LBRACKET);
			{
				if ((tokenSet_9_.member(LA(1))))
				{
					expression();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(ref currentAST, (AST)returnAST);
					}
					{    // ( ... )*
						for (;;)
						{
							if ((LA(1)==COMMA))
							{
								match(COMMA);
								expression();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(ref currentAST, (AST)returnAST);
								}
							}
							else
							{
								goto _loop96_breakloop;
							}
							
						}
_loop96_breakloop:						;
					}    // ( ... )*
				}
				else if ((LA(1)==RBRACKET)) {
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				
			}
			match(RBRACKET);
			arrayRank_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_20_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = arrayRank_AST;
	}
	
	public void mapEntry() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode mapEntry_AST = null;
		
		try {      // for error handling
			expression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			match(COLON);
			expression();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(ref currentAST, (AST)returnAST);
			}
			if (0==inputState.guessing)
			{
				mapEntry_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
				mapEntry_AST = (Solenoid.Expressions.SerializableNode) astFactory.make((AST)(Solenoid.Expressions.SerializableNode) astFactory.create(EXPR,"entry","Solenoid.Expressions.MapEntryNode"), (AST)mapEntry_AST);
				currentAST.root = mapEntry_AST;
				if ( (null != mapEntry_AST) && (null != mapEntry_AST.getFirstChild()) )
					currentAST.child = mapEntry_AST.getFirstChild();
				else
					currentAST.child = mapEntry_AST;
				currentAST.advanceChildToEnd();
			}
			mapEntry_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_21_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = mapEntry_AST;
	}
	
	public void namedArgument() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode namedArgument_AST = null;
		
		try {      // for error handling
			bool synPredMatched111 = false;
			if (((LA(1)==ID) && (LA(2)==ASSIGN)))
			{
				int _m111 = mark();
				synPredMatched111 = true;
				inputState.guessing++;
				try {
					{
						match(ID);
						match(ASSIGN);
					}
				}
				catch (RecognitionException)
				{
					synPredMatched111 = false;
				}
				rewind(_m111);
				inputState.guessing--;
			}
			if ( synPredMatched111 )
			{
				Solenoid.Expressions.NamedArgumentNode tmp108_AST = null;
				tmp108_AST = (Solenoid.Expressions.NamedArgumentNode) astFactory.create(LT(1), "Solenoid.Expressions.NamedArgumentNode");
				astFactory.makeASTRoot(ref currentAST, (AST)tmp108_AST);
				match(ID);
				match(ASSIGN);
				expression();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				namedArgument_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else if ((tokenSet_9_.member(LA(1))) && (tokenSet_22_.member(LA(2)))) {
				argument();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(ref currentAST, (AST)returnAST);
				}
				namedArgument_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_23_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = namedArgument_AST;
	}
	
	public void boolLiteral() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = new ASTPair();
		Solenoid.Expressions.SerializableNode boolLiteral_AST = null;
		
		try {      // for error handling
			if ((LA(1)==TRUE))
			{
				Solenoid.Expressions.BooleanLiteralNode tmp110_AST = null;
				tmp110_AST = (Solenoid.Expressions.BooleanLiteralNode) astFactory.create(LT(1), "Solenoid.Expressions.BooleanLiteralNode");
				astFactory.addASTChild(ref currentAST, (AST)tmp110_AST);
				match(TRUE);
				boolLiteral_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else if ((LA(1)==FALSE)) {
				Solenoid.Expressions.BooleanLiteralNode tmp111_AST = null;
				tmp111_AST = (Solenoid.Expressions.BooleanLiteralNode) astFactory.create(LT(1), "Solenoid.Expressions.BooleanLiteralNode");
				astFactory.addASTChild(ref currentAST, (AST)tmp111_AST);
				match(FALSE);
				boolLiteral_AST = (Solenoid.Expressions.SerializableNode)currentAST.root;
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_2_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = boolLiteral_AST;
	}
	
	public new Solenoid.Expressions.SerializableNode getAST()
	{
		return (Solenoid.Expressions.SerializableNode) returnAST;
	}
	
	private void initializeFactory()
	{
		if (astFactory == null)
		{
			astFactory = new ASTFactory("Solenoid.Expressions.SerializableNode");
		}
		initializeASTFactory( astFactory );
	}
	static public void initializeASTFactory( ASTFactory factory )
	{
		factory.setMaxNodeType(71);
	}
	
	public static readonly string[] tokenNames_ = new string[] {
		@"""<0>""",
		@"""EOF""",
		@"""<2>""",
		@"""NULL_TREE_LOOKAHEAD""",
		@"""EXPR""",
		@"""OPERAND""",
		@"""false""",
		@"""true""",
		@"""and""",
		@"""or""",
		@"""xor""",
		@"""in""",
		@"""is""",
		@"""between""",
		@"""like""",
		@"""matches""",
		@"""null""",
		@"""LPAREN""",
		@"""SEMI""",
		@"""RPAREN""",
		@"""ASSIGN""",
		@"""DEFAULT""",
		@"""QMARK""",
		@"""COLON""",
		@"""PLUS""",
		@"""MINUS""",
		@"""STAR""",
		@"""DIV""",
		@"""MOD""",
		@"""POWER""",
		@"""BANG""",
		@"""DOT""",
		@"""POUND""",
		@"""ID""",
		@"""DOLLAR""",
		@"""COMMA""",
		@"""AT""",
		@"""LBRACKET""",
		@"""RBRACKET""",
		@"""PROJECT""",
		@"""RCURLY""",
		@"""SELECT""",
		@"""SELECT_FIRST""",
		@"""SELECT_LAST""",
		@"""TYPE""",
		@"""QUOTE""",
		@"""STRING_LITERAL""",
		@"""LAMBDA""",
		@"""PIPE""",
		@"""new""",
		@"""LCURLY""",
		@"""INTEGER_LITERAL""",
		@"""HEXADECIMAL_INTEGER_LITERAL""",
		@"""REAL_LITERAL""",
		@"""EQUAL""",
		@"""NOT_EQUAL""",
		@"""LESS_THAN""",
		@"""LESS_THAN_OR_EQUAL""",
		@"""GREATER_THAN""",
		@"""GREATER_THAN_OR_EQUAL""",
		@"""WS""",
		@"""BACKTICK""",
		@"""BACKSLASH""",
		@"""DOT_ESCAPED""",
		@"""APOS""",
		@"""NUMERIC_LITERAL""",
		@"""DECIMAL_DIGIT""",
		@"""INTEGER_TYPE_SUFFIX""",
		@"""HEX_DIGIT""",
		@"""EXPONENT_PART""",
		@"""SIGN""",
		@"""REAL_TYPE_SUFFIX"""
	};
	
	private static long[] mk_tokenSet_0_()
	{
		long[] data = { 2L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_0_ = new BitSet(mk_tokenSet_0_());
	private static long[] mk_tokenSet_1_()
	{
		long[] data = { 1408758448130L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_1_ = new BitSet(mk_tokenSet_1_());
	private static long[] mk_tokenSet_2_()
	{
		long[] data = { 1134924607015288578L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_2_ = new BitSet(mk_tokenSet_2_());
	private static long[] mk_tokenSet_3_()
	{
		long[] data = { 1408765788162L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_3_ = new BitSet(mk_tokenSet_3_());
	private static long[] mk_tokenSet_4_()
	{
		long[] data = { 1408765788674L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_4_ = new BitSet(mk_tokenSet_4_());
	private static long[] mk_tokenSet_5_()
	{
		long[] data = { 1408765789698L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_5_ = new BitSet(mk_tokenSet_5_());
	private static long[] mk_tokenSet_6_()
	{
		long[] data = { 1134907106097428480L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_6_ = new BitSet(mk_tokenSet_6_());
	private static long[] mk_tokenSet_7_()
	{
		long[] data = { 1408765789954L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_7_ = new BitSet(mk_tokenSet_7_());
	private static long[] mk_tokenSet_8_()
	{
		long[] data = { 1134908514863218434L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_8_ = new BitSet(mk_tokenSet_8_());
	private static long[] mk_tokenSet_9_()
	{
		long[] data = { 17696327240712384L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_9_ = new BitSet(mk_tokenSet_9_());
	private static long[] mk_tokenSet_10_()
	{
		long[] data = { 1134908514913550082L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_10_ = new BitSet(mk_tokenSet_10_());
	private static long[] mk_tokenSet_11_()
	{
		long[] data = { 1134908515383312130L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_11_ = new BitSet(mk_tokenSet_11_());
	private static long[] mk_tokenSet_12_()
	{
		long[] data = { 17696326116638912L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_12_ = new BitSet(mk_tokenSet_12_());
	private static long[] mk_tokenSet_13_()
	{
		long[] data = { 1134908515920183042L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_13_ = new BitSet(mk_tokenSet_13_());
	private static long[] mk_tokenSet_14_()
	{
		long[] data = { 16091095105536L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_14_ = new BitSet(mk_tokenSet_14_());
	private static long[] mk_tokenSet_15_()
	{
		long[] data = { 309238169600L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_15_ = new BitSet(mk_tokenSet_15_());
	private static long[] mk_tokenSet_16_()
	{
		long[] data = { 8912896L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_16_ = new BitSet(mk_tokenSet_16_());
	private static long[] mk_tokenSet_17_()
	{
		long[] data = { -35184381001744L, 255L, 0L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_17_ = new BitSet(mk_tokenSet_17_());
	private static long[] mk_tokenSet_18_()
	{
		long[] data = { 412316991488L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_18_ = new BitSet(mk_tokenSet_18_());
	private static long[] mk_tokenSet_19_()
	{
		long[] data = { 281474976710656L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_19_ = new BitSet(mk_tokenSet_19_());
	private static long[] mk_tokenSet_20_()
	{
		long[] data = { 1136050506922131202L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_20_ = new BitSet(mk_tokenSet_20_());
	private static long[] mk_tokenSet_21_()
	{
		long[] data = { 1133871366144L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_21_ = new BitSet(mk_tokenSet_21_());
	private static long[] mk_tokenSet_22_()
	{
		long[] data = { 1152884945836572608L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_22_ = new BitSet(mk_tokenSet_22_());
	private static long[] mk_tokenSet_23_()
	{
		long[] data = { 34360262656L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_23_ = new BitSet(mk_tokenSet_23_());
	
}
}
