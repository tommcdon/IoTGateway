﻿using System.Numerics;
using Waher.Security.EllipticCurves;

namespace Waher.Networking.XMPP.P2P.E2E
{
	/// <summary>
	/// NIST P-256 Curve
	/// </summary>
	public class NistP256Endpoint : NistEndpoint
    {
		/// <summary>
		/// NIST P-256 Curve
		/// </summary>
		public NistP256Endpoint()
			: this(new NistP256())
		{
		}

		/// <summary>
		/// NIST P-256 Curve
		/// </summary>
		/// <param name="Curve">Curve instance</param>
		public NistP256Endpoint(NistP256 Curve)
			: base(Curve)
		{
		}

        /// <summary>
        /// NIST P-256 Curve
        /// </summary>
        /// <param name="PublicKey">Remote public key.</param>
        public NistP256Endpoint(byte[] PublicKey)
            : base(PublicKey, new NistP256())
        {
        }

		/// <summary>
		/// Local name of the E2E encryption scheme
		/// </summary>
		public override string LocalName => "p256";

		/// <summary>
		/// Security strength of End-to-End encryption scheme.
		/// </summary>
		public override int SecurityStrength => 128;

		/// <summary>
		/// Creates a new key.
		/// </summary>
		/// <param name="SecurityStrength">Overall desired security strength, if applicable.</param>
		/// <returns>New E2E endpoint.</returns>
		public override IE2eEndpoint Create(int SecurityStrength)
		{
			return new NistP256Endpoint();
		}

        /// <summary>
        /// Creates a new endpoint given a private key.
        /// </summary>
        /// <param name="Secret">Secret.</param>
        /// <returns>Endpoint object.</returns>
        public override IE2eEndpoint CreatePrivate(byte[] Secret)
        {
            return new NistP256Endpoint(new NistP256(Secret));
        }

        /// <summary>
        /// Creates a new endpoint given a public key.
        /// </summary>
        /// <param name="PublicKey">Remote public key.</param>
        /// <returns>Endpoint object.</returns>
        public override IE2eEndpoint CreatePublic(byte[] PublicKey)
        {
            return new NistP256Endpoint(PublicKey);
        }
    }
}