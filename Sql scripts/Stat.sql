/*
truncate table stat
truncate table player
truncate table nbastanding
truncate table depthchart
*/
select * from stat

select positiondetail from position

select * from stat

select column_name from nba.INFORMATION_SCHEMA.COLUMNS where table_name='stat'

select * from player

select [position],count(*) from player 
group by [position]

select * from player where position='f'

select max(salary) from player

select * from player where salary=37457154.00

select top 10 * from player where position='c' order by salary desc

select top 10 * from player where position='pf' order by salary desc

select * from position

select * from nbastanding

select * from depthchart