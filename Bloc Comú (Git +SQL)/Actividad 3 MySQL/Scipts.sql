/*A1*/
SELECT *
FROM `usairlineflights2`.`flights`;

/* A2 */
 
select 
Origin,
AVG(ArrDelay) as prom_arribades, 
AVG(DepDelay) as prom_sortides
from 
	usairlineflights2.flights 
group by 
	Origin 
order by 
	Origin;

/*A3*/
select 
Origin, colYear, colMonth,
AVG(ArrDelay) as prom_arribades
from 
	usairlineflights2.flights 
group by 
	Origin, colYear, colMonth
order by 
	Origin;

/*A4*/
select 
	city, colYear, colMonth,
AVG (ArrDelay) as prom_arribades
from 
	usairlineflights2.flights, usairlineflights2.usairports
group by 
	city, colYear, colMonth
order by 
	city;

/*A5*/
select 
	UniqueCarrier, colYear, colMonth,
Count(Cancelled) as VuelosCancelados
From
	usairlineflights2.flights
Where 
	Cancelled = 1
Group by  
	UniqueCarrier, colYear, colMonth
order by 
	VuelosCancelados DESC;

/*A6*/
select TailNum, 
SUM(Distance) as DistanciaRecorrida
From 
	usairlineflights2.flights
Where
	TailNum !=  ""
Group By TailNum
Order By DistanciaRecorrida DESC limit 10; 

/*A7*/
SELECT
	UniqueCarrier,
AVG(DepDelay) as MediaDelay
FROM
	usairlineflights2.flights
Group BY
	UniqueCarrier
ORDER BY
	MediaDelay DESC limit 10;
	