GO
INSERT INTO ACTIVITY (type) VALUES
('Mirador'),
('Caminata'),
('Senderismo'),
('Montañismo'),
('Ciclo paseos'),
('Camping'),
('Arborismo'),
('Tirolinea'),
('Cabalgata'),
('Alojamiento'),
('Fauna silvestre'),
('Avisturismo'),
('Escalada'),
('Rapel'),
('Gastronomía'),
('Puente colgante'),
('Canopy'),
('Cascadas'),
('Meditación'),
('Talleres'),
('Picnic'),
('Pesca deportiva'),
('Deportes náuticos'),
('Lagunas'),
('Piscinas'),
('Paseo en bote'),
('Deportes acuáticos'),
('Ciclo montañismo'),
('Aguas termales'),
('Spa'),
('Piscina natural'),
('Equitación'),
('Lodoterapia'),
('Museos'),
('Hidroterapia'),
('Recorridos de slackline'),
('Tirolesa'),
('Saltos de caida libre'),
('Bungee trampolín'),
('Parapente'),
('Baños turcos'),
('Jacuzzi'),
('Rafting'),
('Paintball'),
('Cuatrimoto'),
('Asados'),
('Glamping');
GO
INSERT INTO [STATE] (name_state) VALUES
('Activo'),
('Inactivo'),
('Disponible'),
('Remodelación'),
('Cerrado'),
('Pendiente'),
('Revisado');
GO
INSERT INTO [ROLE] (name_role) VALUES
('User'),
('Editor'),
('Admin');
GO
INSERT INTO PLACE (name_place, address, latitude, longitude, description, link, state_id) VALUES

('Laguna de Guatavita ', 'Laguna de Guatavita, Sesquilé, Cundinamarca', '4.977521', '-73.775038', 'Laguna sagrada de la cultura precolombina, en ella se escenificaba el legendario rito de El Dorado. En la fauna se pueden encontrar zorros y mirlas de páramo.Dentro de la flora del lugar encontramos frailejones, atrapamoscas, curubos silvestres, entre otros.', 'http://www.colparques.net/LGUATAVITA#aceptar', 3),

('Parque ecoturístico Santuario Chiquito', 'Kilómetro 28 vía Zipaquirá, San Cayetano, Pacho, Cundinamarca', '5.198348', '-74.029621', 'Es una reserva natural que ofrece vistas impresionantes del valle del Magdalena y la región de Pacho. Cuenta con importantes sectores de bosque de niebla y se destaca por sus formaciones rocosas. Hermosos paisajes con cascadas, lagunas, acantilados, flora y fauna de páramo, formaciones rocosas, cumbres puntiagudas y valles inundados de frailejones.', '\nhttps://caminantesdelretorno.com/destino/santuario-chiquito/', 3),

('Parque Natural Chicaque', 'Vía Soacha, Km. 8, Soacha, Mosquera, Cundinamarca', '4.606504', '-74.304797', 'El parque resguarda especies de flora y fauna únicas en el mundo, y es el hogar de más de 100 especies de aves y alrededor de 20 especies de mamíferos. Habitan cientos de especies de aves y mamíferos como perezosos, tigrillos, guatines, borugos, micos nocturnos y puercoespines. Son fuente de agua pura para San Antonio del Tequendama.', '\nhttps://www.chicaque.com/', 3),

('Hacienda Coloma', 'Av. las Palmas Vía Tibacuy, Fusagasugá, Cundinamarca', '4.343180', '-74.377357', 'Hacienda que enseña el proceso completo de producción del café, desde su semilla hasta la esencia de cada sorbo. Recorridos del proceso de cultivo y producción del café.', 'https://www.haciendacoloma.com.co/', 3),

('Reserva natural Peña del Aserradero', 'Albán, Cundinamarca', '4.880088', '-74.435848', 'Sendero de 1200 metros dentro de un bosque nuboso. Esta ubicada dentro de un corredor Andino para la conservación de la biodiversidad en los relictos del bosque y el  abastecimiento hídrico. Se destaca el colibrí endémico y amenazado conocido como Blck Inca. Otras especies de interés como el Torito esmeralda, el Trepatroncos perlado, el chamicero endémico coliplata, el Atrapamoscas barrado y la Tangara de cejas verdes.', 'https://www.facebook.com/events/alb%C3%A1n-cundinamarca/aventura-camino-ecol%C3%B3gico-pe%C3%B1as-del-aserradero-alb%C3%A1n/412263052440842/', 3),

('Parque Aventura La Chorrera', ' Parque Aventura La Chorrera, Choachí, Cundinamarca', '4.587434', '-73.951216', 'Experiencias ecoagroturisticas y turismo de aventura con la intensión de generar espacios de reconocimiento cultural por medio de la riqueza natural.', 'https://lachorrera.com.co/quienes-somos/', 3),

('Tygüa Magüe Ecoparque', 'Vda. Lourdes, Tabio, Cundinamarca', '4.919866', '-74.077877', 'Ubicada en las montañas de Tabio, es un lugar para la educación ambiental y la investigación científica, con proyectos de reforestación y programas para la conservación de especies en peligro de extinción como el oso andino, el cóndor andino y el tigrillo.', 'https://tygua-mague-ecoparque.negocio.site/', 3),

('Piedra Colgada', 'Finca Piedra colgada, Vereda, El Tablon, Susa, Cundinamarca', '5.425196', '-73.846210', 'Finca que queda en una vereda, en ella se pueden hacer caminatas. Mirador hacia la laguna de Fúquene y alrededores, antiguo Camino Empedrado, Farallones de Susa y Carupa.', 'https://ecoglobalexpeditions.com/caminata-ecologica-piedra-colgada/', 3),

('Bioparque La Reserva', 'Vereda el Abra Km 1,2, Cota, Cundinamarca', '4.808084', '-74.116972', 'Conservación de fauna silvestre colombiana, flora y recursos naturales a través de proyectos de educación ambiental e investigación sobre biodiversidad de ecosistemas colombianos.', 'https://www.bioparquelareserva.com/proyectos/', 3),

('Parque de Las Orquídeas del Tequendama', 'kilometro 19 via bogota el colegio, San Antonio Del Tequendama, Cundinamarca', '4.590799', '-74.351327', 'Destino natural que ofrece a sus visitantes un paseo con deliciosos aromas, colores y formas en el reino de las flores más exóticas del mundo. Las orquídeas en su variedad inagotable se exponen en los troncos de los árboles, o sobre rocas. Además hay una amplia colección de heliconias, bromelias y plantas ornamentales, que forman un jardín, recreado por pájaros y mariposas.', 'https://www.orquideasdeltequendama.com/', 3),

('Agro Parque Sabio Mutis', 'Tena, La Mesa, Cundinamarca', '4.623500', '-74.429887', 'El parque cuenta con exhibiciones interactivas y educativas que muestran la importancia de la agricultura sostenible y la conservación de la biodiversidad. Con más de 40 hectáreas de tierra y alrededor de 7.000 variedades de plantas, entre ellas las orquídeas, cactus y suculentas, hortalizas y plantas medicinales.', 'https://www.uniminuto.edu/agroparque-sabio-mutis', 3),

('Rocas de Suesca', 'Av 15#103-70 Bogotá Vereda Cacicazgo Frente a estación de trén, Suesca, Cundinamarca', '5.117163', '-73.794132', 'Las rocas de Suesca corresponden a la roca sedimentaria tipo arenisca. La roca ofrece buena adherencia para escalar.', 'http://www.colparques.net/SUESCA#aceptar', 3),

('Laguna de Fúquene', 'Fúquene, Cundinamarca', '5.468890', '-73.744732', 'Es un cuerpo de agua dulce. Posee numerosas islas, una de ellas fue santuario de los muiscas. Entre las especies se encuentran el pato zambullidor, el pato real, la gallareta, el pelícano, el halcón peregrino, y la especie endémica de pez llamada blanquillo de Fúquene.', 'https://oaica.car.gov.co/vercaso.php?id=241 ', 3),

('Observatorio de Colibríes', 'Variante Frailejonal, El Cerrito, La Calera, Cundinamarca', '4.664592', '-73.964449', 'Un refugio seguro y una fuente de alimento para el sustento y reproducción de los colibries.', 'https://www.observatoriodecolibries.com/visits', 3),

('Parque Nacional Natural Chingaza', 'Parque Nacional Natural Chingaza, La Calera, Cundinamarca', '4.547703', '-73.733354', 'Actualmente es un remanso de fauna y flora andina, revelando al visitante el secreto de la vida. Los ecosistemas altoandinos, bosques subandinos y páramos predominan en la zona, actuando además como refugio de majestuosas reservas de fauna y flora.', 'https://www.parquesnacionales.gov.co/portal/en/ecotourism/orinoco-region/chingaza-national-natural-park/', 3),

('Laguna El Tabacal ', 'Via Laguna el Tabacal, La Vega, Cundinamarca', '5.026122', '-74.328299', 'Lo que atrae a muchos a la laguna es la sinfónica melodía que exhiben las más de 400 especies aves reportadas en el sitio, considerándose como el tercer lugar de avistamiento de aves para Colombia', 'https://caminatasecologicasbogota.com/laguna-el-tabacal/', 3),

('Cascada La Chorrera', 'Choachí, Cundinamarca', '4.597420', '-73.9599860', 'Es considerada la cascada más alta del país con una altura de 590 metros y es uno de los atractivos turísticos más visitados de la región.', 'https://www.roadtrip.travel/roadtrips/caminando-por-un-bosque-de-niebla-a-la-cascada-la-chorrera-la-mas-alta-de-colombia', 3),

('Centro Comercial Centro Chia', 'Av. Pradilla # 9-00 East, Chía, Cundinamarca', '4.865861', '-74.036504', 'Centro Comercial Naturalmente Único que cuenta con más de 25.000 mts de parque natural en donde encontrarás caminos verdes que te llevarán a explorar aves, peces, patos, tortugas.', 'https://www.centrochia.com.co/parque/', 3),

('Jardín Encantado: Observatorio de Colibríes', 'Finca la tortuguita en San Francisco, Cundinamarca ', '4.978893', '-74.293357', 'Atrae más de 25 especies de colibríes de las 165 que han sido clasificadas en Colombia. Este lugar es un punto de referencia para los ornitólogos, fotógrafos especializados, ambientalistas y amantes de la naturaleza. ', 'https://www.jardinencantado.net/#services', 3),

('Parque Arqueológico Piedras del Tunjo', 'Cl. 5, Facatativá, Cundinamarca', '4.816296', '-74.346265', 'Se encuentran abrigos rocosos con un sinnúmero de pinturas rupestres que conforman un importante patrimonio arqueológico.', 'http://www.colparques.net/FACA#aceptar', 3),

('Reserva Natural El Chochal de Siecha', 'Vda. La Trinidad, Guasca, Cundinamarca', '4.805952', '-73.887662', 'Un lugar ideal para estar en contacto con naturaleza, armando recorridos.', 'https://elchochaldesiecha.com/', 3),

('Truchas El Abuelo', 'Lago timana, vereda el salitre, Guasca, Cundinamarca', '4.823780', '-73.935774', 'Restaurante ubicado a 45 minutos de Bogotá vía sopo o vía la calera, se cultivan truchas en piscifactorías y se venden frescas o preparadas en diferentes platos de la gastronomía local.', 'https://truchaselabuelo.com/', 3),

('Parque Ecológico Rancho Los Leones', 'Vía La Vega - Sasaima #13, La Vega, Cundinamarca', '4.998677', '-74.339630', 'Una finca de recreación familiar ubicada en la región de Cundinamarca, cerca de la ciudad de Bogotá.', 'https://www.rancholosleones.com/', 3),

('Sendero Ecológico La Cascada', '253207, Albán, Cundinamarca', '4.894798', '-74.437380', 'Esta finca cuenta con un sendero ecológico que conduce a una hermosa cascada. Se puede apreciar una gran variedad de plantas y animales, incluyendo aves y mariposas. ', 'https://granjacascada.jimdofree.com/', 3),

('Parque Tematico Cafetero Finca la Pedregoza', 'Santandercito - San Antonio Del Tequendama, Cundinamarca', '4.595592', '-74.341129',  'Un espacio con sabor a café y con el ritmo de los cantos de las aves mas hermosas. Ofrece a los visitantes la oportunidad de experimentar la vida en el campo, aprender sobre la agricultura sostenible y disfrutar de la naturaleza.', 'https://fincalapedregoza.co/parque-tem%C3%A1tico-cafetero', 3),

('Parque Natural Los Tunos', 'Troncal del Tequendama, km 11.8, Vda. Arracachal, San Antonio Del Tequendama, Cundinamarca', '4.566895', '-74.318221', 'Reserva natural que hace parte del cinturón de bosque de niebla mejor conservado del valle del río Magdalena en pleno corazón del país. Cuenta con un proyecto de conservación del bosque de Niebla y aves como: Torcaza Collareja, Turpial Montañero, Azulejo Montañero y Tangara de Lentejuelas.', 'https://lostunos.com.co/', 3),

('Mirador de la Laguna de Suesca', 'Vereda Ovejeras, Suesca, Cundinamarca', '5.194765', '-73.765709', 'Este mirador ofrece una vista panorámica de la Laguna de Suesca, el cual es un cuerpo de agua natural que se encuentra en una zona montañosa rodeada de bosques y senderos.', 'https://mirador-de-la-laguna-de-suesca.negocio.site/', 3),

('Desierto de Sabrinsky', 'Mosquera, Cundinamarca', '4.666550', '-74.285454', 'Las condiciones climáticas son áridas, en su suelo la lluvia es escasa. Se encuentra ubicado en un terreno rocoso ofreciendo un paisaje exótico por el colorido de la tierra que pasa de rojo intenso a terracotas y naranja.', 'http://mosqueracundinamarca.micolombiadigital.gov.co/turismo/desierto-mondonedo-o-sabrinsky', 3),

('Guandalay Ecoparque Ancestral', 'Vereda Quebrada Grande, San Antonio Del Tequendama, Cundinamarca', '4.608985', '-74.365305', 'Lugar de contemplación y apreciación de la naturaleza.', 'https://www.guandalay.xyz/', 3),

('Lagunas de Siecha', 'Guasca, Cundinamarca', '4.765984', '-73.852778', 'Son un conjunto de lagunas ubicadas en el Parque Nacional Natural Chingaza, en la Cordillera Oriental de los Andes colombianos.', 'https://montanascolombianas.com/siecha-lakes-1-day/?lang=en', 3),

('Piedras Del Chivo Negro', 'Bojacá, Cundinamarca', '4.716965', '-74.324486', 'Un sitio arqueológico que alberga una serie de petroglifos precolombinos tallados en rocas que tienen formas abstractas y geométricas, y se cree que fueron hechos por los muiscas.', 'https://sitiosdeturistas.blogspot.com/2020/02/piedras-de-chivo-negro.html', 3),

('Finca Agroecológica Nigayala', 'km. 10 Finca la reserva Vereda, Jerusalén, La Calera, Cundinamarca', '4.678170', '-73.928424', 'Cabañas rústicas en madera, con chimenea y energía solar, rodeado de naturaleza y montaña, en una finca ecológica', 'https://www.tripadvisor.es/Attraction_Review-g1222951-d12548015-Reviews-Finca_Agroecologica_Nigayala-La_Calera_Cundinamarca_Department.html', 3),

('Café Jaguar Finca La Esperanza', 'Altos de Yayatá, Silvania, Cundinamarca', '4.418350', '-74.389222', 'Finca productora de café exótico colombiano. ', 'https://jaguarcoffeeonline.com/', 3),

('Boquemonte Reserva Natural', 'Km 4.8, Variante Soacha - La Mesa Rural, Soacha, Cundinamarca', '4.606920', '-74.297002', 'Se encuentran en una de las mejores zonas rurales de preservación ecológica del país con más de 1500 especies de flora y fauna y con el inigualable clima Bosque de niebla ó Bosque Alto Andino. Es el hogar de una gran variedad de especies animales y vegetales, muchas de ellas en peligro de extinción, como el oso hormiguero, el jaguar, el cóndor de los Andes y el guanaco.', 'https://boquemonte.com/', 3),

('Embalse del Neusa', 'Neusa - San Cayetano, Cogua, Cundinamarca', '5.135917', '-73.967913', 'Dentro del área del parque se desarrollan ambientes especiales para el hábitat de diferentes especies de fauna y animales silvestres, además de gran cultivo de truchas que se pueden pescar. Este paraíso natural tiene una extensión de bosque andino con plantaciones forestales de pino, eucalipto y bosque nativo y un embalse con especies de peces como la trucha arco iris, el capitán de la sabana y la guapucha.', 'http://www.colparques.net/NEUSA#aceptar', 3),

('Cascadas del Chupal', 'Cascadas del Chupal, La Vega, Cundinamarca', '5.045438', '-74.306864', 'Son 4 cascadas, para hacer la caminata es necesario contar con un buen estado físico, ropa cómoda y zapatos de buen agarre, ya que hay varios transectos con altas pendientes y lisos por las piedras.', 'https://mujerforestal.com/cascadas-del-chupal-la-vega-cundinamarca/', 3),

('Parque Ecológico Carmen De Los Juncales', 'Parque Ecológico Carmen De Los Juncales, Tabio, Cundinamarca', '4.932913', '-74.111626', 'Parque ecológico donde se hacen recorridos, observando la recuperación de biodiversidad en la región sabanera.', 'https://www.fueradelarutina.com/planes-para-hacer-en-tabio/parque-ecologico-carmen-de-los-juncales/', 3),

('Cascada de Nemosten-Sueva', 'Cascada de, Nemosten, Junín, Cundinamarca', '4.810974', '-73.733441', 'Cascada de Sueva que se encuentra en la vereda Nemusten municipio Junin inspección de Sueva, Cascadas cerca a Bogotá. Las rutas diseñadas y ofrecidas por Conexión Natural están clasificadas acorde a 5 niveles de dificultad.', 'https://caminatasecologicasbogota.com/cascada-de-sueva/', 3),

('Embalse del Guavio', 'Cl. 4 #31, Gachalá, Cundinamarca', '4.695557', '-73.509249', 'Es una central hidroeléctrica, aunque fue construida para generar la energía que abastece gran parte del país, hoy es un gran atractivo turístico, por ser escenario de diferentes actividades recreativas. ', 'https://elturismoencolombia.com/a-donde-ir/cundinamarca-colombia-travel/embalse-guavio-gachala-cundinamarca/', 3),

('Mirador Piedra Capira', '50, Guaduas, Cundinamarca', '5.090303', '-74.635073', 'Entre los lugares que se pueden contemplar desde el Mirador de la Piedra Capira encontramos el rio Magdalena y los nevados del Ruiz, Santa Isabel y Tolima, además de varios municipios como Mariquita, Ambalema y Honda. Los visitantes que deseen hacer el recorrido a pie, pueden hacerlo en una caminata de aproximadamente una hora por el camino real.', 'https://portavozdigital.com/mirador-piedra-capira-guaduas/', 3),

('Reserva Ecopalacio Chingaza', 'Vda. La Trinidad, Guasca, Cundinamarca', '4.742241', '-73.850906', 'Una experiencia exclusiva, personalizada y completa en el Páramo de Chingaza, donde te sumergirás en el ecosistema de páramo. Acercamiento a la fauna local, entre ellas: el oso de anteojos, aves como el barbudito de páramo, o venados de cola blanca.', 'http://ecopalaciochingaza.co/', 3),

('Camping Montañero', 'Cl. 14d #8-27, Facatativá, Cundinamarca', '4.822156', '-74.358002', 'Campamentos y expediciones temáticas que contribuyen al fortalecimiento de habilidades blandas y a la conexión con la riqueza natural, cultural e histórica del departamento de Cundinamarca', 'https://www.campingmontanero.com/', 3),

('Reserva Natural El Zoque', 'Km 6.5 Via Guasca - Gacheta, Vereda Pastor Ospina 57 Guasca, Cundinamarca', '4.850441', '-73.835817', 'Largas caminatas para descubrir el Páramo hasta actividades y talleres de siembra de fauna nativa. Esta ubicada en el páramo de Guasca a una hora de Bogotá. A 6.5 kilómetros del pueblo de Guasca vía Gachetá se encuentra la Reserva El Zoque.', 'https://www.reservaelzoque.co/', 3),

('Granja Guacamaya', 'Guacamaya, Chipaque, Cundinamarca', '4.43051', '-74.07570', 'Granja familiar lleno de naturaleza muy cerca a Bogotá, en el municipio de Chipaque Cundinamarca.', 'https://granjaguacamaya.com/', 3),

('Finca Ecoturística Mirador De San Antonio', 'Vereda La Escuela, Tibacuy, Cundinamarca', '4.34768', '-74.45230', 'Proyecto familiar turístico y lugar ideal para disfrutar de la naturaleza y la belleza escénica de la región.', 'https://www.facebook.com/MiradorSAntonio/', 3),

('Termales Santa Mónica', 'Vereda Resguardo km 2, Choachí, Cundinamarca', '4.549078', '-73.917113', 'Emplazado en las laderas de la Cordillera Oriental de los Andes, este paraíso natural cuenta con aguas termales medicinales que proveen a piscinas, jacuzzi, salas de sauna y turco.', 'https://www.termalessantamonica.com/', 3),

('Bosque Ecuestre & Valle del Pony', 'Vereda Meusa Sopó, Km 10 vía Sopó La Calera, Sopó, Cundinamarca', '4.843097', '-73.934001', 'Escuela de Equitación enfocada en el amor por los Caballos y la Naturaleza con una vista sobre la Sabana.', 'https://www.facebook.com/bosquecuestre/', 3),

('La Isabela Centro Ecuestre', 'Vereda Santa bárbara centro, Tabio, Cundinamarca', '4.932045', '-74.092320', 'Escuela de equitación lugar de inspiración y recursos para los amantes de los caballos y la equitación en Colombia. Ofrece servicios de entrenamiento y paseos a caballo, rutas de cabalgata y eventos ecuestres.', 'https://www.instagram.com/isabelaecuestre/?hl=es', 3),

('El Gran Pozo Azufrado', 'Km 3.5, Jerusalén - Tocaima, Cundinamarca', '4.481051', '-74.648493', 'Centro vacacional familiar con la naturaleza, certificado con las aguas azufradas y el lodo medicinal Azufrado, que se puede encontrar en la fuente natural Acuata.', 'https://www.facebook.com/ElGranPozoAzufrado/?locale=es_LA', 3),

('Los Pocitos Azufrados de Tocaima', 'km 3, Jerusalén - Tocaima, Cundinamarca', '4.479141', '-74.645806', 'Centro recreacional que cuenta con pozos de agua y lodo azufrados, poseedores de excelentes propiedades medicinales, terapéuticas, y cosméticas', 'https://www.facebook.com/LosPocitosAzufrados/?locale=es_LA', 3),

('Kalú Night Picnic Theater', 'Chía, Cundinamarca', '4.87243', '-74.03835', 'Experiencia única de teatro al aire libre, el disfrute de la naturaleza y el arte en armonía. Una compañía teatral con sede en Colombia que se especializa en espectáculos de teatro de picnic.', 'https://www.instagram.com/kalu_picnictheater/?hl=es', 3),

('Barlovento Travesías en Velero', 'Embalse de Tominé, Guatavita, Cundinamarca', '4.943209',  '-73.843838', 'Es un lugar ideal para disfrutar de la naturaleza y navegar en velero por el Embalse de Tominé.', 'https://barloventopaseosenvelero.com/', 3),

('Kombai Park Montearroyo', 'Parque Tématico de Aventura, Km 30 Via, Bogotá-La Vega', '4.899270', '-74.310365', 'Parque temático en un terreno grandioso cuya topografía entrega grandes opciones de diversión y ocupación de tiempo en familia.', 'https://kombaipark.com/', 3),

('La Bandolera Trailrides', 'Via San Vicente, Suesca, Cundinamarca', '5.072293', '-73.775852', 'Una hacienda que nace del amor a los animales, el campo y los viajes de a caballo y a lomo de mula.', 'https://labandolera.com/', 3),

('Termales Los Volcanes', 'Km 13 vía, El Sisga - Macheta, Chocontá, Cundinamarca', '5.092886', '-73.640661', 'Una empresa dedicada al bienestar por medio de aguas termales que se destacan por sus grandes propiedades y un complejo eco turístico. Rodeado de naturaleza enmarcado por las imponentes montañas del paisaje cundinamarqués.', 'https://termaleslosvolcanes.com/', 3),

('Termales Aguas Calientes Guasca', 'Vda. Santuario, Guasca, Cundinamarca', '4.876155', '-73.857844', 'Complejo turístico con piscinas termales, áreas de descanso, restaurantes, zonas de camping y alojamiento en cabañas y habitaciones. Ofrece servicios de relajación y turismo en una zona rodeada de naturaleza y aguas termales.', 'https://www.instagram.com/termalesguasca/?hl=es-la', 3),

('Suescalada', 'Cra. 23 #53A-05 3er piso, Teusaquillo, Bogotá, Cundinamarca', '4.64234', '-74.07352', 'Destino popular para los amantes de la escalada en roca en Colombia. Cuenta con numerosos riscos y paredes de roca natural que son ideales para la escalada deportiva y tradicional. En cuanto a la flora y fauna, cuenta con especies nativas, incluyendo aves como el cóndor andino, el búho y el colibrí, y animales como zorros, armadillos y serpientes.', 'https://www.suescalada.com/', 3),

('Club Trango Aventura', 'Cra. 5, Suesca, Cacicazgo, Suesca, Cundinamarca', '5.091861', '-73.792082', 'Agencia de viajes por Colombia, Perú, Bolivia, Estados Unidos, Nepal y mucho más.', 'https://www.facebook.com/clubtrangoaventura/', 3),

('Termales El Zipa', 'Tabio, Cundinamarca', '4.923420', '-74.104710', 'Fuentes de aguas termales y recurso natural unido a la historia ancestral del lugar que con sus minerales activos proporciona beneficios medicinales, en su agradable destino para relajarse y disfrutar sumergido en sus cálidas aguas rodeadas de naturaleza.', 'http://www.tabio-cundinamarca.gov.co/turismo/termales-el-zipa ', 3),

('Termales Aguas Calientes', 'Vda. Santuario, Guasca, Cundinamarca', '4.876154', '-73.857845', 'Cuenta con fenómenos como agua a 75 ºC, baños a vapor, un nacimiento de petróleo y la cascada que tiene una conformación rocosa. Especies nativas, incluyendo aves como el tucán y el colibrí, así como mamíferos como el zorro y el oso hormiguero.', 'https://www.covioriente.co/termales-aguas-calientes-area-protegida-donde-podra-disfrutar-de-una-experiencia-natural/', 3),

('A Pata con Joaco Punto de Atención', 'Cra. 5 #6-57, Villeta, Cundinamarca', '5.01272', '-74.47039', 'Servicio de guías turísticos para quienes desean conocer los atractivos locales.', 'http://apataconjoaco.com/ ', 3),

('Cabalgatas Trote & Galope', 'La Calera, Cundinamarca', '4.716914', '-73.978629', 'Agencia de turismo dedicada a promocionar y ofrecer servicios de paseos a caballo en la región', 'https://www.instagram.com/cabalgatastroteygalope/?hl=es', 3),

('Senda Nativa Naturaleza y Aventura', 'Cra. 1 #250, Guatavita, Guasca, Cundinamarca', '4.912791', '-73.897195', 'Un pueblo con hermosas casas blancas con techos en barro cocido y una arquitectura colonial. Frente a este pueblo el embalse de Tominé, una hermosa represa de agua rodeada de montañas. y a 17 kilómetros del pueblo la famosa laguna de Guatavita la cual dio origen a la leyenda del dorado. Enseñanza de la historia nativa del lugar, costumbres, rituales, los mitos y leyendas de los primeros habitantes de estas tierras, de los indígenas.', 'http://sendanativa.com/es/', 3),

('Lagos Del Siecha Restaurante y Pesca ', 'Sector Paso Hondo, Vda. La Trinidad, Guasca, Cundinamarca', '4.799171', '-73.891873', 'El lugar cuenta con varios tipos de alojamiento, incluyendo cabañas, domos y tiendas de campaña, así como zonas comunes con piscinas, juegos infantiles y áreas para hacer fogatas. Una de las principales atracciones del lugar son los lagos, que están rodeados por senderos. Se pueden observar frailejones, lagunas, lagunetas y quebradas; patos de páramo, águilas, colibríes, horneros, azulejos, tángaras.', 'https://www.lagosdelsiecha.com/', 3),

('Senderos del Sisga', 'Senderos del Sisga, Chocontá, Cundinamarca', '5.050942', '-73.703780', 'Un espacio donde poder compaginar el deporte y la aventura con un entorno ecológico,  disfrutar de paisajes y riquezas naturales, y al mismo tiempo incentivar conciencia ecológica, aportando al cuidado del medio ambiente. Es posible observar especies como el pino ciprés y el pino pátula representativos del bosque alto andino.', 'https://www.senderosdelsisga.com/', 3),

('Cascada El Escobo', 'Vereda La Vistosa Vereda El Tigre, Vergara, Cundinamarca', '5.114022', '-74.364311', 'Ubicado en Vergara un municipio con una belleza inmensa, hace parte de la llamada Región Gualiva, y aunque es un poco frío, ofrece comida deliciosa, deportes extremos y turismo ecológico.', 'https://www.sitiosturisticoscolombia.com/cascada-el-escobo/', 3),

('Pacho Aventura', 'Cl. 6 #17-92 #17-2 a, Pacho, Cundinamarca', '5.130199', '-74.157249', 'Agencia de tours ecológicos encargados de hacer de tu viaje a Pacho una experiencia memorable en contacto con la naturaleza. Observación de aves como el Tangara carafuego, el Carpintero real, Colibrí colihabano, el Halcón murcielaguero y el Vencejo acollarado.', 'https://www.instagram.com/pacho.aventura/?hl=es', 3),

('Camino Real La mesa ', 'La mesa, Cundinamarca', '4.547379', '-74.536511', 'Hace parte de la red de vías que funcionaron desde la época de la colonia como rutas de intercambio comercial y de conexión entre las poblaciones. El recorrido se inicia desde la zona urbana del municipio transitando por caminos de vereda, caminos reales de piedra y realizando algunos pasos por la ladera del río.', 'https://awali.com.co/destino/caminatas/camino-real-de-la-mesa/', 3),

('Reserva Biológica El Encenillo', 'Guasca, Cundinamarca', '4.794789','-73.908675', 'La importancia de la Reserva Biológica Encenillo radica en que allí se encuentran relictos naturales de bosques alto andinos de encenillo. Especies vegetales típicas del bosque de encenillo son las orquídeas, bromelias y briófitas. La reserva es un refugio para la fauna representada en mamíferos como coatíes, armadillos, zorros de páramo y numerosas especies de aves residentes y migratorias.', 'https://natura.org.co/reservas/reserva-biologica-el-encenillo/', 3),

('Parque Natural Montaña del Oso', 'Chía, Cundinamarca', '4.829793', '-74.013705', 'El lugar, es un espacio propicio para el avistamiento de flora y fauna propia del ecosistema. ', 'https://turismo.chia-cundinamarca.gov.co/2020/02/02/blind-climber-ascends-old-man-of-hoy/', 3),

('Ecoparque Nukasa', 'Zipaquirá, Cundinamarca', '5.027991', '-74.014044', 'Ecoparque único en las cercanías de Zipaquirá. Tiene un bosque altoandino y un subpáramo muy conservado lo que permite una experiencia transformadora y diferente a nuestros visitantes. Actualmente se cuenta con 8 senderos, alrededor de los elementos esenciales (aire, tierra, agua y fuego) y el avistamiento de aves. También hay producción apícola y pistas de downhill.', 'https://retos.co/ecosistema/comunidades/14/', 3),

('Peña de Juaica', 'Km 7 via Tenjo, Tabio, Cundinamarca', '4.905417', '-74.129441', 'Esta montaña guarda diversas leyendas, se dice que desde la cima de la peña muchos indígenas decidieron suicidarse gracias al sometimiento y maltrato por parte de los españoles. ', 'https://parchexbogota.com/articulo/la-pena-de-juaica-la-montana-del-misterio/', 3),

('Finca el Tinto', 'Vereda La Libertad, La Vega, Cundinamarca', '4.955921', '-74.332672', 'Todo el proceso culmina en una catación y conociendo los metodos y formas de preparar el mejor café de colombia', 'https://finca-el-tinto.negocio.site/?utm_source=gmb&utm_medium=referral', 3),

('Parque Embalse El Hato', 'Via Hato, Carmen de Carupa, Cundinamarca', '5.303198', '-73.905324', 'Una hacienda en medio de un embalse rodeado de jardines y zonas verdes. En la reserva natural se encuentra gran diversidad de flora y fauna.', 'http://www.colparques.net/HATO#aceptar', 3),

('Reserva Natural Paraíso Andino', 'Km 12.5, Vía La Vega - Sasaima, Cundinamarca', '4.951936', '-74.371390', 'Es un espacio natural para el aprendizaje, el descanso, la contemplación y la reconexión con la naturaleza. ', 'https://www.instagram.com/reservaparaisoandino/?hl=es', 3),

('Termales los Volcanes', 'Choachí, Cundinamarca', '4.549843', '-73.917663', 'El lugar propicio para conectar con la naturaleza; un espacio especial donde encuentras aguas termales disponibles para la revitalización de tu mente y tu cuerpo. Cuenta con cuatro piscinas de agua termal, agua Mineromedicinal.', 'https://termaleslosvolcanes.com/', 3),

('Salto de las Monjas', 'El Ocaso-Cachipay, Cachipay, La Mesa, Cundinamarca', '4.690426', '-74.440391', 'La caminata Salto de Las Monjas es una espectacular caída de treinta metros de altura ubicada entre los municipios de Cachipay y La Mesa. ', 'https://caminatasalairelibre.com/destinos/salto-de-las-monjas/', 3),

('Farallones De Sutatausa', 'Sutatausa, Cundinamarca', '5.229958', '-73.834828', 'Los Farallones De Sutatausa son una formación rocosa.', 'https://senderosyrutas.net/senderismo-farallones-de-sutatausa-colombia/', 3),

('Parque Ecoturístico Puente Sopo', 'Sopó, Cundinamarca', '4.936581', '-73.983028', 'Parque ecoturístico.', 'https://parques.car.gov.co/PaginaWeb/DetalleParque.aspx', 3),

('Cerro del Majui', 'Cota, Cundinamarca', '4.806248', '-74.121785', 'El cerro del Majuy se encuentra en los que en la antigüedad fueran los territorios del cacique muisca, era considerado uno de sus sitios sagrados, en la actualidad es protegido por las comunidades muiscas que habitan la zona en la actualidad.', 'https://awali.com.co/destino/caminatas/cerro-del-majuy/', 3),

('Páramo Verjón', 'km 15.5, Choachi - Bogotá, Cundinamarca', '4.565445', '-74.005747', 'Se recorrerá parte del páramo, iremos hasta llegar a la Laguna de Teusacá ,una de las 5 lagunas sagradas de los Muiscas.', 'https://ecoglobalexpeditions.com/caminata-ecologica-laguna-del-verjon/', 3),

('Aves Internacionales Colombia', 'Kilometro 4 Agua de Dios - Nilo, Vereda Belén de Malachí, Cundinamarca', '4.351577', '-74.651368', 'Aves Internacionales Colombia es una organización sin ánimo de lucro, que enfoca sus esfuerzos en el estudio, conservación y monitoreo de aves residentes y migratorias en el Neotrópico.', 'https://www.facebook.com/manadulcereservanatural/', 3),

('Salto de Versalles', 'Guaduas, Cundinamarca', '5.123651', '-74.597592', 'El Salto de Versalles es una cascada de agua de un poco más de 40 metros de altura que se produce por la unión de los ríos San Francisco, El Guadual y Limonar.', 'https://baquianos.com/es/blog/salto-de-versalles-como-llegar', 3),

('Cerro el Tablazo', 'Cra. 85 #8899, Bogotá, Supatá, Cundinamarca', '5.012235', '-74.204242',  'Cerro El Tablazo, es una icónica e imponente montaña ubicada en el municipio de Subachoque, a solo una hora de Bogotá. Su cima se alza por encima de los 3.400 metros sobre el nivel del mar. En esta caminata ecológica tendrás la combinación perfecta entre la tranquilidad del páramo, y la exuberancia bosque alto andino.', 'https://caminatasalairelibre.com/destinos/cerro-el-tablazo/', 3),

('Periland Eco Park', 'La Naveta, Cajicá, El Tejar, Cundinamarca', '4.955881', '-74.018778', 'Es una iniciativa de la Fundación Bosques Verdes, entidad que se ha dedicado desde el año 2015 a conectar familias, colectivos, amigos y sus mascotas con la naturaleza por medio de la educación ambiental.', 'https://www.perilandecoparque.com/', 3),

('Finca Cafetera la Esmeralda', 'Cl. 2, Ubaque, Cundinamarca', '4.4941256', '-73.9185005', 'La Esmeralda es una finca familiar que desde el 2009 se dedica a  cultivar y procesar café de excelente calidad.', 'https://fincalaesmeraldaub.wixsite.com/fincalaesmeralda', 3),

('Parque Ecológico Jerico ', 'Km 33 Autopista Medellín, La Vega, Cundinamarca', '4.911722', '-74.296696', 'Parque con vistas hemosas.', 'https://www.facebook.com/parquejerico/?locale=es_LA', 3),

('Salto de los Micos', '50, Villeta, Cundinamarca', '5.017715', '-74.478932', 'Este destino turístico es una maravilla de Villeta, se trata de 7 imponentes cascadas, cada una con características diferentes y con su pozo propio.', 'https://www.sitiosturisticoscolombia.com/salto-de-los-micos-villeta/', 3),

('Desierto de Checua', 'Nemocón, Cundinamarca', '5.132712', '-73.867140', 'Tour de las Orquídeas Colombianas, Birding & Birdwatching en el Tour Andino. ', 'https://www.facebook.com/ForestOfOrchids/?paipv=0&eav=AfZBVMeySUIKqyY8jpzJG_XXV6zK09ieK60JD7HnRathMTt7W9_a5QkVM1YFTTIL2pw&_rdr', 3),

('Cerro de Quinini:', 'Tibacuy, Cundinamarca', '4.328529', '-74.497311', 'La región corresponde al antiguo territorio indígena de los Panches, de cuya civilización hay muestras en los petroglifos o arte rupestre y entierros funerarios dispersos en la zona.', 'https://www.roadtrip.travel/roadtrips/caminata-al-cerro-de-quinini-montana-sagrada-de-la-luna', 3),

('Parque Verde Agua', 'Hda cimitarra, Fusagasugá, Cundinamarca', '4.360785', '-74.335350', 'Quininí hace referencia a “Montaña sagrada de la Luna ó Diosa de la Luna", es lo que significa en lengua de las comunidades indígenas que allí habitaron.', 'https://www.facebook.com/parqueverdeyagua/?locale=es_LA', 3),

('Kombai Park Montearroyo', 'Km 30 Via, Bogotá-La Vega, La Vega', '4.899196', '-74.310429', 'En un terreno grandioso cuya topografía nos permite entregarte grandes opciones de diversión y ocupación de tu tiempo en familia.', 'https://kombaipark.com/nosotros/', 3),

('Parque Monarca', '250208, Tenjo, Cundinamarca', '4.855989', '-74.095044', 'Es un parque para toda la familia, donde puedes realizar eventos especiales mientras disfrutas de la tranquilidad de un ambiente sano, podrás observar diferentes animales de granja y otros como son aves silvestres y diferentes insectos', 'https://parque-monarca.negocio.site/#summary', 3),

('Parque Ozagua', 'Sibaté, Cundinamarca', '4.462801', '-74.265305', 'Parque ecológico que brinda espacios formativos, recreativos y educativos, para aquellos que buscan experiencias significativas en entornos naturales. ', 'https://parqueozagua.com/nosotros', 3),

('Cañón de la Lechuza', 'Suesca, Cundinamarca', '5.103291', '-73.758741', 'La caminata se puede hacer por dos vías: por el filo de la montaña o por el nivel del río. Ambos caminos se conectan en la orilla del lago en donde propios y visitantes dedican sus horas a la práctica del canotaje e incluso, como un balneario refrescante. ', 'https://viajaporcolombia.com/sitios-turisticos/cundinamarca/canon-de-la-lechuza_260/', 3);

GO
CREATE PROCEDURE spAuditChanges
    @TableName NVARCHAR(128),
    @Action NVARCHAR(50)
AS
BEGIN
    INSERT INTO AUDIT (date, view_action, action)
    VALUES (GETDATE(), @TableName, @Action)
END;

GO
-- Trigger para la tabla ACTIVITY
CREATE TRIGGER tr_AuditActivity
ON dbo.ACTIVITY
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Action NVARCHAR(50)
    IF EXISTS (SELECT * FROM INSERTED)
    BEGIN
        IF EXISTS (SELECT * FROM DELETED)
            SET @Action = 'UPDATE'
        ELSE
            SET @Action = 'INSERT'
    END
    ELSE IF EXISTS (SELECT * FROM DELETED)
        SET @Action = 'DELETE'

    EXEC spAuditChanges 'ACTIVITY', @Action
END;

GO
-- Trigger para la tabla PICTURE
CREATE TRIGGER tr_AuditPicture
ON dbo.PICTURE
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Action NVARCHAR(50)
    IF EXISTS (SELECT * FROM INSERTED)
    BEGIN
        IF EXISTS (SELECT * FROM DELETED)
            SET @Action = 'UPDATE'
        ELSE
            SET @Action = 'INSERT'
    END
    ELSE IF EXISTS (SELECT * FROM DELETED)
        SET @Action = 'DELETE'

    EXEC spAuditChanges 'PICTURE', @Action
END;

GO
-- Trigger para la tabla PLACE
CREATE TRIGGER tr_AuditPlace
ON dbo.PLACE
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Action NVARCHAR(50)
    IF EXISTS (SELECT * FROM INSERTED)
    BEGIN
        IF EXISTS (SELECT * FROM DELETED)
            SET @Action = 'UPDATE'
        ELSE
            SET @Action = 'INSERT'
    END
    ELSE IF EXISTS (SELECT * FROM DELETED)
        SET @Action = 'DELETE'

    EXEC spAuditChanges 'PLACE', @Action
END;

GO
-- Trigger para la tabla REVIEW
CREATE TRIGGER tr_AuditReview
ON dbo.REVIEW
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Action NVARCHAR(50)
    IF EXISTS (SELECT * FROM INSERTED)
    BEGIN
        IF EXISTS (SELECT * FROM DELETED)
            SET @Action = 'UPDATE'
        ELSE
            SET @Action = 'INSERT'
    END
    ELSE IF EXISTS (SELECT * FROM DELETED)
        SET @Action = 'DELETE'

    EXEC spAuditChanges 'REVIEW', @Action
END;

GO
-- Trigger para la tabla ROLE
CREATE TRIGGER tr_AuditRole
ON dbo.ROLE
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Action NVARCHAR(50)
    IF EXISTS (SELECT * FROM INSERTED)
    BEGIN
        IF EXISTS (SELECT * FROM DELETED)
            SET @Action = 'UPDATE'
        ELSE
            SET @Action = 'INSERT'
    END
    ELSE IF EXISTS (SELECT * FROM DELETED)
        SET @Action = 'DELETE'

    EXEC spAuditChanges 'ROLE', @Action
END;

GO
-- Trigger para la tabla STATE
CREATE TRIGGER tr_AuditState
ON dbo.STATE
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Action NVARCHAR(50)
    IF EXISTS (SELECT * FROM INSERTED)
    BEGIN
        IF EXISTS (SELECT * FROM DELETED)
            SET @Action = 'UPDATE'
        ELSE
            SET @Action = 'INSERT'
    END
    ELSE IF EXISTS (SELECT * FROM DELETED)
        SET @Action = 'DELETE'

    EXEC spAuditChanges 'STATE', @Action
END;

GO
-- Trigger para la tabla TICKET
CREATE TRIGGER tr_AuditTicket
ON dbo.TICKET
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Action NVARCHAR(50)
    IF EXISTS (SELECT * FROM INSERTED)
    BEGIN
        IF EXISTS (SELECT * FROM DELETED)
            SET @Action = 'UPDATE'
        ELSE
            SET @Action = 'INSERT'
    END
    ELSE IF EXISTS (SELECT * FROM DELETED)
        SET @Action = 'DELETE'

    EXEC spAuditChanges 'TICKET', @Action
END;

GO
-- Trigger para la tabla USER
CREATE TRIGGER tr_AuditUser
ON dbo.[USER]
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Action NVARCHAR(50)
    IF EXISTS (SELECT * FROM INSERTED)
    BEGIN
        IF EXISTS (SELECT * FROM DELETED)
            SET @Action = 'UPDATE'
        ELSE
            SET @Action = 'INSERT'
    END
    ELSE IF EXISTS (SELECT * FROM DELETED)
        SET @Action = 'DELETE'

    EXEC spAuditChanges 'USER', @Action
END;

GO
-- Trigger para la tabla ACTIVITY_PLACE
CREATE TRIGGER tr_AuditActivity_Place
ON dbo.ACTIVITY_PLACE
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Action NVARCHAR(50)
    IF EXISTS (SELECT * FROM INSERTED)
    BEGIN
        IF EXISTS (SELECT * FROM DELETED)
            SET @Action = 'UPDATE'
        ELSE
            SET @Action = 'INSERT'
    END
    ELSE IF EXISTS (SELECT * FROM DELETED)
        SET @Action = 'DELETE'

    EXEC spAuditChanges 'ACTIVITY_PLACE', @Action
END;

GO
-- Trigger para la tabla PICTURE_PLACE
CREATE TRIGGER tr_AuditPicture_Place
ON dbo.PICTURE_PLACE
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Action NVARCHAR(50)
    IF EXISTS (SELECT * FROM INSERTED)
    BEGIN
        IF EXISTS (SELECT * FROM DELETED)
            SET @Action = 'UPDATE'
        ELSE
            SET @Action = 'INSERT'
    END
    ELSE IF EXISTS (SELECT * FROM DELETED)
        SET @Action = 'DELETE'

    EXEC spAuditChanges 'PICTURE_PLACE', @Action
END;

GO
-- Trigger para la tabla REVIEW_PLACE
CREATE TRIGGER tr_AuditReview_Place
ON dbo.REVIEW_PLACE
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Action NVARCHAR(50)
    IF EXISTS (SELECT * FROM INSERTED)
    BEGIN
        IF EXISTS (SELECT * FROM DELETED)
            SET @Action = 'UPDATE'
        ELSE
            SET @Action = 'INSERT'
    END
    ELSE IF EXISTS (SELECT * FROM DELETED)
        SET @Action = 'DELETE'

    EXEC spAuditChanges 'REVIEW_PLACE', @Action
END;
