// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: CCotizaciones.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace PROYDOS {

  /// <summary>Holder for reflection information generated from CCotizaciones.proto</summary>
  public static partial class CCotizacionesReflection {

    #region Descriptor
    /// <summary>File descriptor for CCotizaciones.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CCotizacionesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChNDQ290aXphY2lvbmVzLnByb3RvIsABChBDQ290aXphY2lvbk9yZGVuEhMK",
            "C2NvZF9lbXByZXNhGAEgASgJEhYKDm51bV9jb3RpemFjaW9uGAIgASgJEhYK",
            "DmZlY19jb3RpemFjaW9uGAMgASgJEhMKC2NvZF91c3VhcmlvGAQgASgJEhEK",
            "CWFzaXN0ZW50ZRgFIAEoCRIXCg9mZWNfdmVuY2ltaWVudG8YBiABKAkSEgoK",
            "Y29kX2VzdGFkbxgHIAEoCRISCgpub21fZXN0YWRvGAggASgJImUKFUdldEND",
            "b3RpemFjaW9uUmVxdWVzdBIUCgxwY29kX2VtcHJlc2EYASABKAkSHAoUcGNv",
            "ZF91c3VhcmlvX3dpbmRvd3MYAiABKAkSGAoQcG51bV9jb21wYXJhdGl2bxgD",
            "IAEoCSJ1ChZHZXRDQ290aXphY2lvblJlc3BvbnNlEisKEENDb3RpemFjaW9u",
            "T3JkZW4YASABKAsyES5DQ290aXphY2lvbk9yZGVuEhYKDnBlcnJvcl90ZWNu",
            "aWNvGAIgASgJEhYKDnBlcnJvcl91c3VhcmlvGAMgASgJMlwKFENDb3RpemFj",
            "aW9uZXNTZXJ2aWNlEkQKD0dldENvdGl6YWNpb25lcxIWLkdldENDb3RpemFj",
            "aW9uUmVxdWVzdBoXLkdldENDb3RpemFjaW9uUmVzcG9uc2UwAUIKqgIHUFJP",
            "WURPU2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::PROYDOS.CCotizacionOrden), global::PROYDOS.CCotizacionOrden.Parser, new[]{ "CodEmpresa", "NumCotizacion", "FecCotizacion", "CodUsuario", "Asistente", "FecVencimiento", "CodEstado", "NomEstado" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PROYDOS.GetCCotizacionRequest), global::PROYDOS.GetCCotizacionRequest.Parser, new[]{ "PcodEmpresa", "PcodUsuarioWindows", "PnumComparativo" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PROYDOS.GetCCotizacionResponse), global::PROYDOS.GetCCotizacionResponse.Parser, new[]{ "CCotizacionOrden", "PerrorTecnico", "PerrorUsuario" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class CCotizacionOrden : pb::IMessage<CCotizacionOrden> {
    private static readonly pb::MessageParser<CCotizacionOrden> _parser = new pb::MessageParser<CCotizacionOrden>(() => new CCotizacionOrden());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CCotizacionOrden> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PROYDOS.CCotizacionesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CCotizacionOrden() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CCotizacionOrden(CCotizacionOrden other) : this() {
      codEmpresa_ = other.codEmpresa_;
      numCotizacion_ = other.numCotizacion_;
      fecCotizacion_ = other.fecCotizacion_;
      codUsuario_ = other.codUsuario_;
      asistente_ = other.asistente_;
      fecVencimiento_ = other.fecVencimiento_;
      codEstado_ = other.codEstado_;
      nomEstado_ = other.nomEstado_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CCotizacionOrden Clone() {
      return new CCotizacionOrden(this);
    }

    /// <summary>Field number for the "cod_empresa" field.</summary>
    public const int CodEmpresaFieldNumber = 1;
    private string codEmpresa_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CodEmpresa {
      get { return codEmpresa_; }
      set {
        codEmpresa_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "num_cotizacion" field.</summary>
    public const int NumCotizacionFieldNumber = 2;
    private string numCotizacion_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string NumCotizacion {
      get { return numCotizacion_; }
      set {
        numCotizacion_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "fec_cotizacion" field.</summary>
    public const int FecCotizacionFieldNumber = 3;
    private string fecCotizacion_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FecCotizacion {
      get { return fecCotizacion_; }
      set {
        fecCotizacion_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "cod_usuario" field.</summary>
    public const int CodUsuarioFieldNumber = 4;
    private string codUsuario_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CodUsuario {
      get { return codUsuario_; }
      set {
        codUsuario_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "asistente" field.</summary>
    public const int AsistenteFieldNumber = 5;
    private string asistente_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Asistente {
      get { return asistente_; }
      set {
        asistente_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "fec_vencimiento" field.</summary>
    public const int FecVencimientoFieldNumber = 6;
    private string fecVencimiento_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FecVencimiento {
      get { return fecVencimiento_; }
      set {
        fecVencimiento_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "cod_estado" field.</summary>
    public const int CodEstadoFieldNumber = 7;
    private string codEstado_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CodEstado {
      get { return codEstado_; }
      set {
        codEstado_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "nom_estado" field.</summary>
    public const int NomEstadoFieldNumber = 8;
    private string nomEstado_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string NomEstado {
      get { return nomEstado_; }
      set {
        nomEstado_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CCotizacionOrden);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CCotizacionOrden other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (CodEmpresa != other.CodEmpresa) return false;
      if (NumCotizacion != other.NumCotizacion) return false;
      if (FecCotizacion != other.FecCotizacion) return false;
      if (CodUsuario != other.CodUsuario) return false;
      if (Asistente != other.Asistente) return false;
      if (FecVencimiento != other.FecVencimiento) return false;
      if (CodEstado != other.CodEstado) return false;
      if (NomEstado != other.NomEstado) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (CodEmpresa.Length != 0) hash ^= CodEmpresa.GetHashCode();
      if (NumCotizacion.Length != 0) hash ^= NumCotizacion.GetHashCode();
      if (FecCotizacion.Length != 0) hash ^= FecCotizacion.GetHashCode();
      if (CodUsuario.Length != 0) hash ^= CodUsuario.GetHashCode();
      if (Asistente.Length != 0) hash ^= Asistente.GetHashCode();
      if (FecVencimiento.Length != 0) hash ^= FecVencimiento.GetHashCode();
      if (CodEstado.Length != 0) hash ^= CodEstado.GetHashCode();
      if (NomEstado.Length != 0) hash ^= NomEstado.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (CodEmpresa.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(CodEmpresa);
      }
      if (NumCotizacion.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(NumCotizacion);
      }
      if (FecCotizacion.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(FecCotizacion);
      }
      if (CodUsuario.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(CodUsuario);
      }
      if (Asistente.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Asistente);
      }
      if (FecVencimiento.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(FecVencimiento);
      }
      if (CodEstado.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(CodEstado);
      }
      if (NomEstado.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(NomEstado);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (CodEmpresa.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CodEmpresa);
      }
      if (NumCotizacion.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(NumCotizacion);
      }
      if (FecCotizacion.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(FecCotizacion);
      }
      if (CodUsuario.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CodUsuario);
      }
      if (Asistente.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Asistente);
      }
      if (FecVencimiento.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(FecVencimiento);
      }
      if (CodEstado.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CodEstado);
      }
      if (NomEstado.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(NomEstado);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CCotizacionOrden other) {
      if (other == null) {
        return;
      }
      if (other.CodEmpresa.Length != 0) {
        CodEmpresa = other.CodEmpresa;
      }
      if (other.NumCotizacion.Length != 0) {
        NumCotizacion = other.NumCotizacion;
      }
      if (other.FecCotizacion.Length != 0) {
        FecCotizacion = other.FecCotizacion;
      }
      if (other.CodUsuario.Length != 0) {
        CodUsuario = other.CodUsuario;
      }
      if (other.Asistente.Length != 0) {
        Asistente = other.Asistente;
      }
      if (other.FecVencimiento.Length != 0) {
        FecVencimiento = other.FecVencimiento;
      }
      if (other.CodEstado.Length != 0) {
        CodEstado = other.CodEstado;
      }
      if (other.NomEstado.Length != 0) {
        NomEstado = other.NomEstado;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            CodEmpresa = input.ReadString();
            break;
          }
          case 18: {
            NumCotizacion = input.ReadString();
            break;
          }
          case 26: {
            FecCotizacion = input.ReadString();
            break;
          }
          case 34: {
            CodUsuario = input.ReadString();
            break;
          }
          case 42: {
            Asistente = input.ReadString();
            break;
          }
          case 50: {
            FecVencimiento = input.ReadString();
            break;
          }
          case 58: {
            CodEstado = input.ReadString();
            break;
          }
          case 66: {
            NomEstado = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// client asking for all locations 
  /// </summary>
  public sealed partial class GetCCotizacionRequest : pb::IMessage<GetCCotizacionRequest> {
    private static readonly pb::MessageParser<GetCCotizacionRequest> _parser = new pb::MessageParser<GetCCotizacionRequest>(() => new GetCCotizacionRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetCCotizacionRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PROYDOS.CCotizacionesReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetCCotizacionRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetCCotizacionRequest(GetCCotizacionRequest other) : this() {
      pcodEmpresa_ = other.pcodEmpresa_;
      pcodUsuarioWindows_ = other.pcodUsuarioWindows_;
      pnumComparativo_ = other.pnumComparativo_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetCCotizacionRequest Clone() {
      return new GetCCotizacionRequest(this);
    }

    /// <summary>Field number for the "pcod_empresa" field.</summary>
    public const int PcodEmpresaFieldNumber = 1;
    private string pcodEmpresa_ = "";
    /// <summary>
    /// Codigo de empresa referenciada del core para el que se ejecuta el proceso,
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PcodEmpresa {
      get { return pcodEmpresa_; }
      set {
        pcodEmpresa_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "pcod_usuario_windows" field.</summary>
    public const int PcodUsuarioWindowsFieldNumber = 2;
    private string pcodUsuarioWindows_ = "";
    /// <summary>
    /// Codigo de usuario que ejecuta el proceso
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PcodUsuarioWindows {
      get { return pcodUsuarioWindows_; }
      set {
        pcodUsuarioWindows_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "pnum_comparativo" field.</summary>
    public const int PnumComparativoFieldNumber = 3;
    private string pnumComparativo_ = "";
    /// <summary>
    /// Codigo de usuario que ejecuta el proceso
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PnumComparativo {
      get { return pnumComparativo_; }
      set {
        pnumComparativo_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetCCotizacionRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetCCotizacionRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (PcodEmpresa != other.PcodEmpresa) return false;
      if (PcodUsuarioWindows != other.PcodUsuarioWindows) return false;
      if (PnumComparativo != other.PnumComparativo) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (PcodEmpresa.Length != 0) hash ^= PcodEmpresa.GetHashCode();
      if (PcodUsuarioWindows.Length != 0) hash ^= PcodUsuarioWindows.GetHashCode();
      if (PnumComparativo.Length != 0) hash ^= PnumComparativo.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (PcodEmpresa.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(PcodEmpresa);
      }
      if (PcodUsuarioWindows.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(PcodUsuarioWindows);
      }
      if (PnumComparativo.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(PnumComparativo);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (PcodEmpresa.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PcodEmpresa);
      }
      if (PcodUsuarioWindows.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PcodUsuarioWindows);
      }
      if (PnumComparativo.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PnumComparativo);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetCCotizacionRequest other) {
      if (other == null) {
        return;
      }
      if (other.PcodEmpresa.Length != 0) {
        PcodEmpresa = other.PcodEmpresa;
      }
      if (other.PcodUsuarioWindows.Length != 0) {
        PcodUsuarioWindows = other.PcodUsuarioWindows;
      }
      if (other.PnumComparativo.Length != 0) {
        PnumComparativo = other.PnumComparativo;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            PcodEmpresa = input.ReadString();
            break;
          }
          case 18: {
            PcodUsuarioWindows = input.ReadString();
            break;
          }
          case 26: {
            PnumComparativo = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// response with all locations 
  /// </summary>
  public sealed partial class GetCCotizacionResponse : pb::IMessage<GetCCotizacionResponse> {
    private static readonly pb::MessageParser<GetCCotizacionResponse> _parser = new pb::MessageParser<GetCCotizacionResponse>(() => new GetCCotizacionResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetCCotizacionResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PROYDOS.CCotizacionesReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetCCotizacionResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetCCotizacionResponse(GetCCotizacionResponse other) : this() {
      cCotizacionOrden_ = other.cCotizacionOrden_ != null ? other.cCotizacionOrden_.Clone() : null;
      perrorTecnico_ = other.perrorTecnico_;
      perrorUsuario_ = other.perrorUsuario_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetCCotizacionResponse Clone() {
      return new GetCCotizacionResponse(this);
    }

    /// <summary>Field number for the "CCotizacionOrden" field.</summary>
    public const int CCotizacionOrdenFieldNumber = 1;
    private global::PROYDOS.CCotizacionOrden cCotizacionOrden_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::PROYDOS.CCotizacionOrden CCotizacionOrden {
      get { return cCotizacionOrden_; }
      set {
        cCotizacionOrden_ = value;
      }
    }

    /// <summary>Field number for the "perror_tecnico" field.</summary>
    public const int PerrorTecnicoFieldNumber = 2;
    private string perrorTecnico_ = "";
    /// <summary>
    /// Mensaje de error técnico del error ocurrido. Si todo está bien se retorna el valor 000000
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PerrorTecnico {
      get { return perrorTecnico_; }
      set {
        perrorTecnico_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "perror_usuario" field.</summary>
    public const int PerrorUsuarioFieldNumber = 3;
    private string perrorUsuario_ = "";
    /// <summary>
    /// En caso de ocurrir un error, se retorna el mensaje en len
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PerrorUsuario {
      get { return perrorUsuario_; }
      set {
        perrorUsuario_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetCCotizacionResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetCCotizacionResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(CCotizacionOrden, other.CCotizacionOrden)) return false;
      if (PerrorTecnico != other.PerrorTecnico) return false;
      if (PerrorUsuario != other.PerrorUsuario) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (cCotizacionOrden_ != null) hash ^= CCotizacionOrden.GetHashCode();
      if (PerrorTecnico.Length != 0) hash ^= PerrorTecnico.GetHashCode();
      if (PerrorUsuario.Length != 0) hash ^= PerrorUsuario.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (cCotizacionOrden_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(CCotizacionOrden);
      }
      if (PerrorTecnico.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(PerrorTecnico);
      }
      if (PerrorUsuario.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(PerrorUsuario);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (cCotizacionOrden_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CCotizacionOrden);
      }
      if (PerrorTecnico.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PerrorTecnico);
      }
      if (PerrorUsuario.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PerrorUsuario);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetCCotizacionResponse other) {
      if (other == null) {
        return;
      }
      if (other.cCotizacionOrden_ != null) {
        if (cCotizacionOrden_ == null) {
          CCotizacionOrden = new global::PROYDOS.CCotizacionOrden();
        }
        CCotizacionOrden.MergeFrom(other.CCotizacionOrden);
      }
      if (other.PerrorTecnico.Length != 0) {
        PerrorTecnico = other.PerrorTecnico;
      }
      if (other.PerrorUsuario.Length != 0) {
        PerrorUsuario = other.PerrorUsuario;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (cCotizacionOrden_ == null) {
              CCotizacionOrden = new global::PROYDOS.CCotizacionOrden();
            }
            input.ReadMessage(CCotizacionOrden);
            break;
          }
          case 18: {
            PerrorTecnico = input.ReadString();
            break;
          }
          case 26: {
            PerrorUsuario = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
