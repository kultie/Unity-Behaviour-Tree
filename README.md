# Unity-Behaviour-Tree
Simple Behaviour Tree implementation for Unity c# base on article of [adnzzzzZ](https://github.com/adnzzzzZ/blog/issues/3)  

Added basic elements of BTs: Composite nodes (Sequence, Selector), Leaf and some Decorator(Inverter)
Feel free to use this for your Unity project.

# Namespace
Kultie.BehaviourTree

# Components
## Context
- All the data for the tree will contains in here.
- All node in the tree will use this as the intermediate to communicate with eachother
- Create your own Context and extending it by BehaviourContext class

## Root
- Root of the tree, these just a place holder and make sense for all you english speaker since tree start will composite node is not understandable
- Create Root using a context an a composite node

## Action Node
- Node that perform an action
- Create your own Action Node by extending Action class

## Composite Node
- Node that contains nodes, these node are the "direction" for the tree
- Create by list of nodes or using params in c#
- Create your own Composite Node by extending Composite class
- There are already built-in Sequence and Selector node


## Decorator Node
- Node that change the result of Action Node
- Create your own Decorator Node by extending Decorator class
- There are already built-in After, DontSucceddInARow, Inverter, RepeateUntilFail node

# How to Use
- Create how many nodes as you want
- Create a root
- Calling root.Update(dt, context) in the Update method of MonoBehavior
