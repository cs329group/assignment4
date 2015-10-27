
# Assignment 4
In this project, you are required to write a program to compute the schedules for activities
in a software project.

##Contributors
* Matt McKillip
* Mason Berhenke
* Kyle Long

##Usage
Call our executable and pass the filename of the input file on the command line.

##Test cases
Our test cases can be found in the /TestFiles directory
### Test Case 1
This is a simple test case to check multiple critical paths

A 1

B 2 A

C 3 B

D 3 B

E 1 C,D


######Output
| Job | Dur| ES | EE | LS | LE |
|-----|----|----|----|----|----|
|A    |1   |0   |1   |0   |1   |
|B    |2   |1   |3   |1   |3   |
|C    |3   |3   |6   |3   |6   |
|D    |3   |3   |6   |3   |6   |
|E    |1   |6   |7   |6   |7   |

Critical Path: A, B, D, E,

A, B, C, E,

-----

### Test Case 2
This test case is taken from homework assignment #3

A 2

B 3

C 2

D 3 A

E 2 B,C

F 1 A,B

G 4 A

H 5 C

I 3 D,F

J 3 E,G

K 2 I

L 2 K

######Output
| Job | Dur| ES | EE | LS | LE |
|-----|----|----|----|----|----|
|A    |2   |0   |2   |0   |2   |
|B    |3   |0   |3   |1   |4   |
|C    |2   |0   |2   |5   |7   |
|D    |3   |2   |5   |2   |5   |
|E    |2   |3   |5   |7   |9   |
|F    |1   |3   |4   |4   |5   |
|G    |4   |2   |6   |5   |9   |
|H    |5   |2   |7   |7   |12  |
|I    |3   |5   |8   |5   |8   |
|J    |3   |6   |9   |9   |12  |
|K    |2   |8   |10  |8   |10  |
|L    |2   |10  |12  |10  |12  |

Critical Path A, D, I, K, L,

-----


### Test Case 3
This test case if from the "Schedule and Planning - PDM" slides. pg 152

A 2

B 6

C 4 A,B

D 1 C

E 3 D

F 1 B

G 5 B

H 1 F,G

I 2 E,H

######Output
| Job | Dur| ES | EE | LS | LE |
|-----|----|----|----|----|----|
|A    |2   |0   |2   |4   |6   |
|B    |6   |0   |6   |0   |6   |
|C    |4   |6   |10  |6   |10  |
|D    |1   |10  |11  |10  |11  |
|E    |3   |11  |14  |11  |14  |
|F    |1   |6   |7   |12  |13  |
|G    |5   |6   |11  |8   |13  |
|H    |1   |11  |12  |13  |14  |
|I    |2   |14  |16  |14  |16  |

Critical Path: B, C, D, E, I,

-----
