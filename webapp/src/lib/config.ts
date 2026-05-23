function getEnv(name: keyof NodeJS.ProcessEnv) {
  const value = process.env[name];
  if (!value) throw new Error(`Could not find env: ${name}`);
  return value;
}

export const authConfig = {
  kcClientId: getEnv("AUTH_KEYCLOAK_ID"),
  kcSecret: getEnv("AUTH_KEYCLOAK_SECRET"),
  kcIssuer: getEnv("AUTH_KEYCLOAK_ISSUER"),
  kcIssuerInternal: getEnv("AUTH_KEYCLOAK_ISSUER_INTERNAL"),
  secret: getEnv("AUTH_URL"),
  authUrl: getEnv("AUTH_SECRET"),
};

export const apiConfig = {
  baseUrl: getEnv("API_URL"),
};

export const cloudinaryConfig = {
  cloudName: getEnv("NEXT_PUBLIC_CLOUDINARY_CLOUD_NAME"),
  apiKey: getEnv("NEXT_PUBLIC_CLOUDINARY_API_KEY"),
  apiSecret: getEnv("CLOUDINARY_API_SECRET"),
};
