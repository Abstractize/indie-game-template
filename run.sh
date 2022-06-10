#!/usr/bin/env bash

# Show env vars
grep -v '^#' .env

# Export env vars
export $(grep -v '^#' .env | xargs)
docker build --build-arg UNITY_EMAIL=$UNITY_EMAIL --build-arg UNITY_PASSWORD=$UNITY_PASSWORD --build-arg UNITY_SERIAL=$UNITY_SERIAL .