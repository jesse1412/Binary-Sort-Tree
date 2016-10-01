using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{

    class BinaryTree
    {

        public BinaryTree parent;
        public BinaryTree child1;
        public BinaryTree child2;
        public int? value;

        public BinaryTree()
        {

            value = null;

        }

        public BinaryTree(int nodeValue)
        {

            value = nodeValue;

        }

        BinaryTree(int nodeValue, BinaryTree nodeParent)
        {

            value = nodeValue;
            parent = nodeParent;

        }

        public void insertValue(int valueToInsert)
        {

            BinaryTree targetChild = null;

            if(value == null)
            {

                value = valueToInsert;
                return;

            }

            if (valueToInsert < value)
            {

                targetChild = child1;

            }

            else if (valueToInsert > value)
            {

                targetChild = child2;

            }

            if (targetChild != null)
            {

                targetChild.insertValue(valueToInsert);

            }

            else
            {

                if (valueToInsert < value)
                {

                    child1 = new BinaryTree(valueToInsert, this);

                }

                else if (valueToInsert > value)
                {

                    child2 = new BinaryTree(valueToInsert, this);

                }

            }

        }

        public BinaryTree getLowestNode()
        {

            if(child1 != null)
            {

                return child1.getLowestNode();

            }

            else
            {

                return this;

            }

        }

        public void removeValue(int valueToRemove)
        {

            try
            {

                if (valueToRemove < value)
                {

                    child1.removeValue(valueToRemove);

                }

                else if (valueToRemove > value)
                {

                    child2.removeValue(valueToRemove);

                }

                else //if value found at this node.
                {

                    //No child case.
                    if (this.child1 == null && this.child2 == null)
                    {

                        if (this.parent != null)
                        {

                            if (this.value > parent.value)
                            {

                                this.parent.child2 = null;

                            }

                            else
                            {

                                this.parent.child1 = null;

                            }

                        }

                        else
                        {

                            this.value = null;

                        }

                    }

                    //2 Children case.
                    else if (this.child1 != null && this.child2 != null)
                    {

                        BinaryTree lowestNode = this.child2.getLowestNode();

                        this.value = lowestNode.value;
                        this.child2.removeValue((int)this.value);

                    }

                    //Single child case.
                    else
                    {

                        BinaryTree liveChild;

                        if (this.child1 != null)
                        {

                            liveChild = this.child1;

                        }

                        else
                        {

                            liveChild = this.child2;

                        }

                        //Not top of tree case.
                        if (this.parent != null)
                        {

                            liveChild.parent = this.parent;

                            if(this.value < this.parent.value)
                            {

                                this.parent.child1 = liveChild;

                            }

                            else
                            {


                                this.parent.child2 = liveChild;
                            }

                        }

                        //Top of tree case.
                        else
                        {

                            this.child1 = liveChild.child1;
                            this.child2 = liveChild.child2;
                            this.value = liveChild.value;

                        }

                    }

                }

            }

            catch
            {


            }

        }

    }

}
