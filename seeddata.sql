INSERT INTO [dbo].[status]
           ([StatusName])
SELECT 'Resolved'
Union
SELECT 'Development'
UNION
SELECT 'Passed to PS'
UNION
SELECT 'Client Testing 1'
UNION
SELECT 'Resolved'

