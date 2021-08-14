-- Obtener datos personales y de contacto de los clientes que hayan cumplido un año con una de sus cuentas. Nota calcular fecha excluir hora.
SELECT 
 cliente.,
 contacto.tipo_contacto, 
 contacto.valor,
 cuenta.numero,
 cuenta.fecha_apertura
FROM cliente
INNER JOIN contacto ON cliente.id = contacto.id_cliente
INNER JOIN cuenta ON cliente.id = cuenta.id_cliente
WHERE EXTRACT(YEAR FROM age(now()DATE, cuenta.fecha_aperturaDATE)) = 1