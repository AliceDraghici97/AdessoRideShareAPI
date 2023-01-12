# AdessoRideShareAPI

A .NET Core web API that allows users to create, manage, and search for travel plans.

Endpoints

Add a travel plan
POST /api/travelplans

Adds a new travel plan to the system.

Request Body
{
    "from": "string",
    "to": "string",
    "date": "yyyy-MM-ddTHH:mm:ss.fffZ",
    "description": "string",
    "maxNoOfSeats": int,
    "occupiedNoOfSeats": int,
    "published": boolean
}

Publish/Unpublish a travel plan
PUT /api/travelplans/{id}

Publishes or unpublishes a travel plan.

Request Body
Copy code
{
    "published": boolean
}

Search for active travel plans
GET /api/travelplans?from={from}&to={to}

Searches for active travel plans that match the specified "from" and "to" locations.

Query Parameters
from - The "from" location to search for.
to - The "to" location to search for.
