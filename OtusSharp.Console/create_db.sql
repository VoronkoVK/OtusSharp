-- Create DB

create database otus_avito;

       
-- Create tables
       
create table users
(
    id    serial primary key,
    name  text  not null,
    email varchar(30) unique not null
);

create table categories
(
    id    serial primary key,
    title text not null
);

create table offers
(
    id          serial primary key,
    author_id   int references users (id) not null ,
    category_id int references categories (id) not null ,
    title       text not null,
    cost        decimal
);


-- Filling in tables

insert into categories (title)
values ('Games');

insert into categories (title)
values ('Cars');

insert into categories (title)
values ('Service');

insert into categories (title)
values ('Booking');

insert into categories (title)
values ('Zoo');


insert into users (name, email)
values ('Ivan', 'ivan@mail.com');

insert into users (name, email)
values ('Petr', 'petr@mail.com');

insert into users (name, email)
values ('Victor', 'victor@mail.com');

insert into users (name, email)
values ('Sergey', 'sergey@mail.com');

insert into users (name, email)
values ('Dmitriy', 'dmitriy@mail.com');


insert into offers (author_id, category_id, title, cost)
values (1, 2, 'Offer for Cars by Ivan', '200');

insert into offers (author_id, category_id, title, cost)
values (2, 1, 'Offer for Games by Petr', '100');

insert into offers (author_id, category_id, title, cost)
values (3, 3, 'Offer for Service by Victor', '50');

insert into offers (author_id, category_id, title, cost)
values (4, 5, 'Offer for Zoo by Sergey', '123');

insert into offers (author_id, category_id, title, cost)
values (5, 4, 'Offer for Booking by Dmitriy', '321');
