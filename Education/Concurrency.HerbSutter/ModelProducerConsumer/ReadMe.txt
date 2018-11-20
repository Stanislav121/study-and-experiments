by 6000ms with Thread.Yeild
14500, 17000, 13400, 14200

by 6000ms with Thread.Sleep(0)
15300, 15500, 15100

by 6000ms with Thread.Sleep(1)
11500, 12800

by 6000ms with Thread.Sleep(50)
6000, 5600, 5700, 6044

by 6000ms with second event
436


by 6000ms with SpinWait(50)
290, 264, 316

by 6000ms withou any wait
309, 355