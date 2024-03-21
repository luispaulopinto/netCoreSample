#!/bin/sh
set -e

until psql -h db -U postgres -d test_database -c '\q'; do
 echo >&2 "Postgres is unavailable - sleeping"
 sleep 1
done

echo >&2 "Postgres is up - executing migrations"
exec "$@"
