-- Obtener datos personales y de contacto de los clientes que hayan cumplido un año con una de sus cuentas. Nota calcular fecha excluir hora.
SELECT 
 cliente.*,
 contacto.tipo_contacto, 
 contacto.valor,
 cuenta.numero,
 cuenta.fecha_apertura
FROM cliente
INNER JOIN contacto ON cliente."id" = contacto.id_cliente
INNER JOIN cuenta ON cliente."id" = cuenta.id_cliente
WHERE EXTRACT(YEAR FROM age(now()::DATE, cuenta.fecha_apertura::DATE)) >= 1

-- Obtener datos personales y de contacto de los clientes con cuentas tipo crédito con un pasivo menor o igual a $200.000
SELECT cl.*,
co.*
FROM cliente
INNER JOIN contacto co ON co.id_cliente = cl."id"
INNER JOIN cuenta cu ON cu.id_cliente = cl."id"
INNER JOIN nota_credito_debito ncd ON ncd.numero_cuenta = cu.numero
WHERE cu.tipo_cuenta = 0 AND
(
    (SELECT case when sum(valor) is null then 0 else sum(valor) end 
			from nota_credito_debito 
			WHERE ncd.numero_cuenta = cu.numero AND es_nota_credito = 1
		)
) <= 200000
GROUP BY cl."id", co.id_cliente

-- Obtener los datos de las cuentas tipo crédito cuyo pasivo sea mayor o igual a su límite de crédito.
SELECT * FROM cuenta cu
WHERE cu.tipo_cuenta = 0 AND
(
    (SELECT CASE WHEN SUM(valor) IS NULL THEN 0 ELSE SUM(valor) END FROM nota_credito_debito WHERE nota_credito_debito.numero_cuenta = cu.numero AND es_nota_credito = 1)
) > cu.credito_limite

-- Obtener los correos electrónicos de clientes con un activo mayor o igual a  $1.000.000 sumado en sus cuentas tipo débito y que aún no tienen una cuenta tipo crédito.
-- 0 = telefono
-- 1 = email
SELECT co.valor
FROM contacto co
INNER JOIN cliente cl ON cl."id" = co.id_cliente
INNER JOIN cuenta cu ON cl."id" = cu.id_cliente
INNER JOIN nota_credito_debito ncd ON ncd.numero_cuenta = cu.numero
WHERE
co.tipo_contacto = 1
AND
cu.tipo_cuenta = 1 
AND
(
    (SELECT case when sum(valor) is null then 0 else sum(valor) end 
			from nota_credito_debito 
			WHERE ncd.numero_cuenta = cu.numero AND es_nota_credito = 0
		)
) > 1000000
AND
(SELECT COUNT(*) FROM cuenta WHERE cu.tipo_cuenta = 0 AND cu.id_cliente = cl."id") < 1
GROUP BY cl."id", co.id_cliente

